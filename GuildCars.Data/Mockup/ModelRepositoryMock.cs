using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class ModelRepositoryMock : IModelRepository
    {
        private static List<Model> models = new List<Model>
        {
            new Model { ModelID = 1, ModelName = "Civic", Make = new Make { MakeID = 1 } },
            new Model { ModelID = 2, ModelName = "Corolla", Make = new Make { MakeID = 2 } },
            new Model { ModelID = 3, ModelName = "Jetta", Make = new Make { MakeID = 3 } },
            new Model { ModelID = 4, ModelName = "840", Make = new Make { MakeID = 4 } },
            new Model { ModelID = 5, ModelName = "Sentra", Make = new Make { MakeID = 5 } },
            new Model { ModelID = 6, ModelName = "Accord", Make = new Make { MakeID = 1 } },
            new Model { ModelID = 7, ModelName = "Rav4", Make = new Make { MakeID = 2 } },
            new Model { ModelID = 8, ModelName = "Golf", Make = new Make { MakeID = 3 } },
            new Model { ModelID = 9, ModelName = "M8", Make = new Make { MakeID = 4 } },
            new Model { ModelID = 10, ModelName = "Altima", Make = new Make { MakeID = 5 } }


        };

        public Model GetModelById(int? id)
        {
            return models.FirstOrDefault(x => x.ModelID == id);
        }

        public List<Model> GetModels()
        {
            return models;
        }
    }
}
