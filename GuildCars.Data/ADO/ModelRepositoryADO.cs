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
    public class ModelRepositoryADO : IModelRepository
    {
        public Model GetModelById(int? id)
        {
            Model model = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        model = new Model();
                        model.ModelID = (int)dr["ModelID"];
                        model.MakeID = (int)dr["MakeID"];
                        model.ModelName = dr["ModelName"].ToString();
                        model.UserID = dr["UserID"].ToString();
                        model.DateAdded = dr["DateAdded"].ToString();
                    }
                }

                return model;
            }
        }

        public List<Model> GetModels()
        {
            List<Model> models = new List<Model>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model row = new Model();

                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.UserID = dr["UserID"].ToString();
                        row.DateAdded = dr["DateAdded"].ToString();

                        models.Add(row);
                    }
                }
            }

            return models;
        }

        public void InsertModel(Model model)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);
                cmd.Parameters.AddWithValue("@DateAdded", model.DateAdded);

                conn.Open();

                cmd.ExecuteNonQuery();

                model.ModelID = (int)param.Value;
            }
        }
    }
}
