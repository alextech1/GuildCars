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
    public class InteriorColorRepositoryADO : IInteriorColorRepository
    {
        public InteriorColor GetInteriorColorById(int? id)
        {
            InteriorColor interiorColor = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InteriorColorID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        interiorColor = new InteriorColor();
                        interiorColor.InteriorColorID = (int)dr["InteriorColorID"];
                        interiorColor.Color = dr["Color"].ToString();
                    }
                }

                return interiorColor;
            }
        }

        public List<InteriorColor> GetInteriorColors()
        {
            List<InteriorColor> interiorColors = new List<InteriorColor>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor row = new InteriorColor();

                        row.InteriorColorID = (int)dr["InteriorColorID"];
                        row.Color = dr["Color"].ToString();


                        interiorColors.Add(row);
                    }
                }
            }

            return interiorColors;
        }

        public void InsertInteriorColor(InteriorColor interiorColor)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@InteriorColorID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Color", interiorColor.Color);

                conn.Open();

                cmd.ExecuteNonQuery();

                interiorColor.InteriorColorID = (int)param.Value;
            }
        }
    }
}
