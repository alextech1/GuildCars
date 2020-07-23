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
    public class MakeRepositoryADO : IMakeRepository
    {
        public Make GetMakeById(int? id)
        {
            Make make = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make = new Make();
                        make.MakeID = (int)dr["MakeID"];
                        make.MakeName = dr["MakeName"].ToString();
                        make.UserID = dr["UserID"].ToString();
                        make.DateAdded = dr["DateAdded"].ToString();
                    }
                }

                return make;
            }
        }

        public List<Make> GetMakes()
        {
            List<Make> makes = new List<Make>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make row = new Make();

                        row.MakeID = (int)dr["MakeID"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.UserID = dr["UserID"].ToString();
                        row.DateAdded = dr["DateAdded"].ToString();

                        makes.Add(row);
                    }
                }
            }

            return makes;
        }

        public void InsertMake(Make make)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MakeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@UserID", make.UserID);
                cmd.Parameters.AddWithValue("@DateAdded", make.DateAdded);

                conn.Open();

                cmd.ExecuteNonQuery();

                make.MakeID = (int)param.Value;
            }
        }
    }
}
