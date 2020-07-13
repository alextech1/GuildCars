using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IGuildRepository
    {
        List<Car> GetAllCars();
        void InsertCar(Car car);
        void UpdateCar(Car car);
        IEnumerable<Car> Search(ListingSearchParameters parameters);
        Car GetCarById(int? id);
    }
}
