using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class StateRepositoryMock : IStateRepository
    {
        private static List<State> states = new List<State>
        {
            new State { StateID = 1, StateAbbr = "AL", StateName = "Alabama" },
            new State { StateID = 2, StateAbbr = "AK", StateName = "Alaska" },
            new State { StateID = 3, StateAbbr = "AZ", StateName = "Arizona" },
            new State { StateID = 4, StateAbbr = "AR", StateName = "Arkansas" },
            new State { StateID = 5, StateAbbr = "CA", StateName = "California" },
            new State { StateID = 6, StateAbbr = "CO", StateName = "Colorado" },
            new State { StateID = 7, StateAbbr = "CT", StateName = "Connecticut" },
            new State { StateID = 8, StateAbbr = "DE", StateName = "Delaware" },
            new State { StateID = 9, StateAbbr = "FL", StateName = "Florida" },
            new State { StateID = 10, StateAbbr = "GA", StateName = "Georgia" },
            new State { StateID = 11, StateAbbr = "HI", StateName = "Hawaii" },
            new State { StateID = 12, StateAbbr = "ID", StateName = "Idaho" },
            new State { StateID = 13, StateAbbr = "IL", StateName = "Illinois" },
            new State { StateID = 14, StateAbbr = "IN", StateName = "Indiana" },
            new State { StateID = 15, StateAbbr = "IA", StateName = "Iowa" },
            new State { StateID = 16, StateAbbr = "KS", StateName = "Kansas" },
            new State { StateID = 17, StateAbbr = "KY", StateName = "Kentucky" },
            new State { StateID = 18, StateAbbr = "LA", StateName = "Louisiana" },
            new State { StateID = 19, StateAbbr = "ME", StateName = "Maine" },
            new State { StateID = 20, StateAbbr = "MD", StateName = "Maryland" },
            new State { StateID = 21, StateAbbr = "MA", StateName = "Massachusetts" },
            new State { StateID = 22, StateAbbr = "MI", StateName = "Michigan" },
            new State { StateID = 23, StateAbbr = "MN", StateName = "Minnesota" },
            new State { StateID = 24, StateAbbr = "MS", StateName = "Mississippi" },
            new State { StateID = 25, StateAbbr = "MO", StateName = "Missouri" },
            new State { StateID = 26, StateAbbr = "MT", StateName = "Montana" },
            new State { StateID = 27, StateAbbr = "NE", StateName = "Nebraska" },
            new State { StateID = 28, StateAbbr = "NV", StateName = "Nevada" },
            new State { StateID = 29, StateAbbr = "NH", StateName = "New Hampshire" },
            new State { StateID = 30, StateAbbr = "NJ", StateName = "New Jersey" },
            new State { StateID = 31, StateAbbr = "NM", StateName = "New Mexico" },
            new State { StateID = 32, StateAbbr = "NY", StateName = "New York" },
            new State { StateID = 33, StateAbbr = "NC", StateName = "North Carolina" },
            new State { StateID = 34, StateAbbr = "ND", StateName = "North Dakota" },
            new State { StateID = 35, StateAbbr = "OH", StateName = "Ohio" },
            new State { StateID = 36, StateAbbr = "OK", StateName = "Oklahoma" },
            new State { StateID = 37, StateAbbr = "OR", StateName = "Oregon" },
            new State { StateID = 38, StateAbbr = "PA", StateName = "Pennsylvania" },
            new State { StateID = 39, StateAbbr = "RI", StateName = "Rhode Island" },
            new State { StateID = 40, StateAbbr = "SC", StateName = "South Carolina" },
            new State { StateID = 41, StateAbbr = "SD", StateName = "South Dakota" },
            new State { StateID = 42, StateAbbr = "TN", StateName = "Tennessee" },
            new State { StateID = 43, StateAbbr = "TX", StateName = "Texas" },
            new State { StateID = 44, StateAbbr = "UT", StateName = "Utah" },
            new State { StateID = 45, StateAbbr = "VT", StateName = "Vermont" },
            new State { StateID = 46, StateAbbr = "VA", StateName = "Virginia" },
            new State { StateID = 47, StateAbbr = "WA", StateName = "Washington" },
            new State { StateID = 48, StateAbbr = "WV", StateName = "West Virginia" },
            new State { StateID = 49, StateAbbr = "WI", StateName = "Wisconsin" },
            new State { StateID = 50, StateAbbr = "WY", StateName = "Wyoming" }

        };

        public State GetStateById(int? id)
        {
            return states.FirstOrDefault(x => x.StateID == id);
        }

        public List<State> GetStates()
        {
            return states;
        }
    }
}
