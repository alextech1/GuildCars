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
    public class RoleRepositoryADO : IRoleRepository
    {
        public GuildRole GetRoleById(int? id)
        {
            GuildRole role = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GuildRolesSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RoleID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        role = new GuildRole();
                        role.RoleID = (int)dr["RoleID"];
                        role.RoleName = dr["RoleName"].ToString();
                    }
                }

                return role;
            }
        }

        public List<GuildRole> GetRoles()
        {
            List<GuildRole> roles = new List<GuildRole>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GuildRolesSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        GuildRole row = new GuildRole();

                        row.RoleID = (int)dr["RoleID"];
                        row.RoleName = dr["RoleName"].ToString();


                        roles.Add(row);
                    }
                }
            }

            return roles;
        }
    }
}
