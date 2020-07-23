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
    public class BodyStyleRepositoryADO : IBodyStyleRepository
    {
        public BodyStyle GetBodyStyleById(int? id)
        {
            BodyStyle bodyStyle = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BodyStyleID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bodyStyle = new BodyStyle();
                        bodyStyle.BodyStyleID = (int)dr["BodyStyleID"];
                        bodyStyle.BodyStyleName = dr["BodyStyleName"].ToString();
                    }
                }

                return bodyStyle;
            }
        }

        public List<BodyStyle> GetBodyStyles()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle row = new BodyStyle();

                        row.BodyStyleID = (int)dr["BodyStyleID"];
                        row.BodyStyleName = dr["BodyStyleName"].ToString();


                        bodyStyles.Add(row);
                    }
                }
            }

            return bodyStyles;
        }

        public void InsertBodyStyle(BodyStyle bodyStyle)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@BodyStyleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@BodyStyleName", bodyStyle.BodyStyleName);

                conn.Open();

                cmd.ExecuteNonQuery();

                bodyStyle.BodyStyleID = (int)param.Value;
            }
        }
    }
}
