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
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public void AddSpecial(Specials specials)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialsID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", specials.Title);
                cmd.Parameters.AddWithValue("@Description", specials.Description);
                cmd.Parameters.AddWithValue("@ImageFileName", specials.ImageFileName);

                conn.Open();

                cmd.ExecuteNonQuery();

                specials.SpecialsID = (int)param.Value;
            }
        }

        public List<Specials> GetSpecials()
        {
            List<Specials> specials = new List<Specials>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials row = new Specials();

                        row.SpecialsID = (int)dr["SpecialsID"];
                        row.Title = dr["Title"].ToString();
                        row.Description = dr["Description"].ToString();
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        specials.Add(row);
                    }
                }
            }

            return specials;
        }

        public Specials GetSpecialsById(int? id)
        {
            Specials specials = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialsID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        specials = new Specials();
                        specials.SpecialsID = (int)dr["SpecialsID"];
                        specials.Title = dr["Title"].ToString();
                        specials.Description = dr["Description"].ToString();
                        specials.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }

                return specials;
            }
        }

        public void Update(Specials specials)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialsID", specials.SpecialsID);
                cmd.Parameters.AddWithValue("@Title", specials.Title);
                cmd.Parameters.AddWithValue("@Description", specials.Description);
                cmd.Parameters.AddWithValue("@ImageFileName", specials.ImageFileName);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveSpecial(int? id)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialsID", id);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
