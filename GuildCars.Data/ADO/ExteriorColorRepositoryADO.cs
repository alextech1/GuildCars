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
    public class ExteriorColorRepositoryADO : IExteriorColorRepository
    {
        public ExteriorColor GetExteriorColorById(int? id)
        {
            ExteriorColor exteriorColor = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExteriorColorID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        exteriorColor = new ExteriorColor();
                        exteriorColor.ExteriorColorID = (int)dr["ExteriorColorID"];
                        exteriorColor.Color = dr["Color"].ToString();
                    }
                }

                return exteriorColor;
            }
        }

        public List<ExteriorColor> GetExteriorColors()
        {
            List<ExteriorColor> extColors = new List<ExteriorColor>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColor row = new ExteriorColor();

                        row.ExteriorColorID = (int)dr["ExteriorColorID"];
                        row.Color = dr["Color"].ToString();


                        extColors.Add(row);
                    }
                }
            }

            return extColors;
        }

        public void InsertExteriorColor(ExteriorColor exteriorColor)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ExteriorColorID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Color", exteriorColor.Color);

                conn.Open();

                cmd.ExecuteNonQuery();

                exteriorColor.ExteriorColorID = (int)param.Value;
            }
        }
    }
}
