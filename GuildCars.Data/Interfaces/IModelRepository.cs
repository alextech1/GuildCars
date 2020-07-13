using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetModels();
        Model GetModelById(int? id);
    }
}
