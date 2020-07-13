using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.EF
{
    public class GuildRepositoryEF : IGuildRepository
    {
        

        public List<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int? id)
        {
            throw new NotImplementedException();
        }

        public void InsertCar(Car car)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> Search(ListingSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
