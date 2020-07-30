using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Mockup
{
    public class MakeRepositoryMock : IMakeRepository
    {
        private static List<Make> makes = new List<Make>
        {
            new Make { MakeID = 1, MakeName = "Honda", DateAdded = DateTime.Now.ToString("MM/dd/yyyy") },
            new Make { MakeID = 2, MakeName = "Toyota", DateAdded = DateTime.Now.ToString("MM/dd/yyyy") },
            new Make { MakeID = 3, MakeName = "Volkswagon", DateAdded = DateTime.Now.ToString("MM/dd/yyyy") },
            new Make { MakeID = 4, MakeName = "BMW", DateAdded = DateTime.Now.ToString("MM/dd/yyyy") },
            new Make { MakeID = 5, MakeName = "Nissan", DateAdded = DateTime.Now.ToString("MM/dd/yyyy") }
        };

        public Make GetMakeById(int? id)
        {
            return makes.FirstOrDefault(x => x.MakeID == id);
        }

        public List<Make> GetMakes()
        {
            return makes;
        }

        public void InsertMake(Make make)
        {
            var newMakeID = makes.Max(x => x.MakeID) + 1;
            make.MakeID = newMakeID;
            makes.Add(make);
        }
    }
}
