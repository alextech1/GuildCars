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
    public class StateRepositoryADO : IStateRepository
    {
        public State GetStateById(int? id)
        {
            State state = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        state = new State();
                        state.StateID = (int)dr["StateID"];
                        state.StateAbbr = dr["StateAbbr"].ToString();
                        state.StateName = dr["StateName"].ToString();
                    }
                }

                return state;
            }
        }

        public List<State> GetStates()
        {
            List<State> states = new List<State>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State row = new State();

                        row.StateID = (int)dr["StateID"];
                        row.StateAbbr = dr["StateAbbr"].ToString();
                        row.StateName = dr["StateName"].ToString();

                        states.Add(row);
                    }
                }
            }

            return states;
        }
    }
}
