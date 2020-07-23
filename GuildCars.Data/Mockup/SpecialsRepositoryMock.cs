using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class SpecialsRepositoryMock : ISpecialsRepository
    {
        private static List<Specials> specialsList = new List<Specials>
        {
            new Specials { SpecialsID = 1, Title = "Fourth Of July Sale", 
                Description = "Get 15% off your purchase today", ImageFileName = "onsale500.png"},
            new Specials { SpecialsID = 2, Title = "Valentine Sale", 
                Description = "Get 5% off your purchase today", ImageFileName = "onsale500.png"},
            new Specials { SpecialsID = 3, Title = "Easter Sale", 
                Description = "Get 5% purchase today", ImageFileName = "onsale500.png"},
            new Specials { SpecialsID = 4, Title = "Colombus Day Sale", 
                Description = "Get 10% purchase today", ImageFileName = "onsale500.png"},
            new Specials { SpecialsID = 5, Title = "Thanksgiving Sale",
                Description = "Get 15% purchase today", ImageFileName = "onsale500.png"}
        };

        public void AddSpecial(Specials specials)
        {
            var newId = specialsList.Max(x => x.SpecialsID) + 1;
            specials.SpecialsID = newId;
            specials.ImageFileName = "onsale500.png";
            specialsList.Add(specials);
        }

        public List<Specials> GetSpecials()
        {
            return specialsList;
        }

        public Specials GetSpecialsById(int? id)
        {
            return specialsList.FirstOrDefault(x => x.SpecialsID == id);
        }

        public void RemoveSpecial(int? id)
        {
            specialsList.RemoveAll(x => x.SpecialsID == id);
        }

        public void Update(Specials specials)
        {
            Specials currentSpecial = GetSpecialsById(specials.SpecialsID);

            currentSpecial.Title = specials.Title;
            currentSpecial.Description = specials.Description;
            currentSpecial.ImageFileName = "onsale500.png";
            //specials.ImageFileName = "onsale500.png";
        }
    }
}
