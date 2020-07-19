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
            new Model { ModelID = 1, ModelName = "Civic" },
            new Model { ModelID = 2, ModelName = "Corolla" },
            new Model { ModelID = 3, ModelName = "Jetta" },
            new Model { ModelID = 4, ModelName = "840" },
            new Model { ModelID = 5, ModelName = "Sentra" },
            new Model { ModelID = 6, ModelName = "Accord" },
            new Model { ModelID = 7, ModelName = "Rav4" },
            new Model { ModelID = 8, ModelName = "Golf"  },
            new Model { ModelID = 9, ModelName = "M8" },
            new Model { ModelID = 10, ModelName = "Altima" }


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
