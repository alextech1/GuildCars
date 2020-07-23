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
    public class TransmissionRepositoryADO : ITransmissionRepository
    {
        public Transmission GetTransmissionById(int? id)
        {
            Transmission transmission = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TransmissionID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        transmission = new Transmission();
                        transmission.TransmissionID = (int)dr["TransmissionID"];
                        transmission.TransmissionType = dr["TransmissionType"].ToString();
                    }
                }

                return transmission;
            }
        }

        public List<Transmission> GetTransmissions()
        {
            List<Transmission> transmissions = new List<Transmission>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission row = new Transmission();

                        row.TransmissionID = (int)dr["TransmissionID"];
                        row.TransmissionType = dr["TransmissionType"].ToString();


                        transmissions.Add(row);
                    }
                }
            }

            return transmissions;
        }

        public void InsertTransmission(Transmission transmission)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@TransmissionID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@TransmissionType", transmission.TransmissionType);

                conn.Open();

                cmd.ExecuteNonQuery();

                transmission.TransmissionID = (int)param.Value;
            }
        }
    }
}
