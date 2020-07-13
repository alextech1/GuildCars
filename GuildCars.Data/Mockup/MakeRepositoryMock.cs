using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class MakeRepositoryMock : IMakeRepository
    {
        private static List<Make> makes = new List<Make>
        {
            new Make { MakeID = 1, MakeName = "Honda" },
            new Make { MakeID = 2, MakeName = "Toyota" },
            new Make { MakeID = 3, MakeName = "Volkswagon" },
            new Make { MakeID = 4, MakeName = "BMW" },
            new Make { MakeID = 5, MakeName = "Nissan" }
        };

        public Make GetMakeById(int? id)
        {
            return makes.FirstOrDefault(x => x.MakeID == id);
        }

        public List<Make> GetMakes()
        {
            return makes;
        }
    }
}
