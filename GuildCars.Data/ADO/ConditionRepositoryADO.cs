using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class ConditionRepositoryADO : IConditionRepository
    {
        public Condition GetConditionById(int? id)
        {
            Condition condition = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConditionID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        condition = new Condition();
                        condition.ConditionID = (int)dr["ConditionID"];
                        condition.ConditionType = dr["ConditionType"].ToString();
                    }
                }

                return condition;
            }
        }

        public List<Condition> GetConditions()
        {
            List<Condition> conditions = new List<Condition>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Condition row = new Condition();

                        row.ConditionID = (int)dr["ConditionID"];
                        row.ConditionType = dr["ConditionType"].ToString();


                        conditions.Add(row);
                    }
                }
            }

            return conditions;
        }

        public void InsertCondition(Condition condition)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ConditionID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@ConditionType", condition.ConditionType);

                conn.Open();

                cmd.ExecuteNonQuery();

                condition.ConditionID = (int)param.Value;
            }
        }
    }
}
