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
    public class PurchaseTypeRepositoryADO : IPurchaseTypeRepository
    {
        public PurchaseType GetPurchaseTypeById(int? id)
        {
            PurchaseType purchaseType = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypesSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PurchaseTypeID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        purchaseType = new PurchaseType();
                        purchaseType.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        purchaseType.PurchaseTypeName = dr["PurchaseTypeName"].ToString();
                    }
                }

                return purchaseType;
            }
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            List<PurchaseType> purchaseTypes = new List<PurchaseType>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypesSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType row = new PurchaseType();

                        row.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        row.PurchaseTypeName = dr["PurchaseTypeName"].ToString();


                        purchaseTypes.Add(row);
                    }
                }
            }

            return purchaseTypes;
        }
    }
}
