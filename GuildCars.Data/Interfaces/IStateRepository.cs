using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetStates();
        State GetStateById(int? id);
    }
}
