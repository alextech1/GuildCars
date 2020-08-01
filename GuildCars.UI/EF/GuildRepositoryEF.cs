using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using GuildCars.UI.Factories;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class GuildRepositoryEF : IGuildRepository
    {
        private readonly ApplicationDbContext _context;

        public GuildRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public GuildRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int? id)
        {
            return _context.Cars.Find(id);
        }

        public void InsertCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> Search(ListingSearchParameters parameters)
        {
            var cars = _context.Cars.ToList();

            List<Car> searchList = new List<Car>();
            List<Car> searchList2 = new List<Car>();
            var makesRepo = MakeFactory.GetRepository();
            var modelRepo = ModelFactory.GetRepository();
            var typesRepo = ConditionFactory.GetRepository();
            var bodyStylesRepo = BodyStyleFactory.GetRepository();
            var transmissionsRepo = TransmissionFactory.GetRepository();
            var extColorsRepo = ExteriorColorFactory.GetRepository();
            var intColorsRepo = InteriorColorFactory.GetRepository();

            searchList = cars;

            if (!string.IsNullOrEmpty(parameters.Make)) //FYI: we do not have a make null
            {
                if (parameters.Mileage == "used")
                {
                    searchList = cars.Where(x => x.ConditionID == 2 && makesRepo.GetMakeById(x.MakeID).MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.ConditionID == 1 && makesRepo.GetMakeById(x.MakeID).MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
                else if (parameters.OnSale == "true")
                {
                    searchList = cars.Where(x => x.OnSale == true && makesRepo.GetMakeById(x.MakeID).MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
                else
                {
                    searchList = cars.Where(x => makesRepo.GetMakeById(x.MakeID).MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
            }

            if (!string.IsNullOrEmpty(parameters.Model)) //FYI: we do not have a model null
            {
                if (parameters.Mileage == "used")
                {
                    searchList = cars.Where(x => x.ConditionID == 2 && modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.ConditionID == 1 && modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else if (parameters.OnSale == "true")
                {
                    searchList = cars.Where(x => x.OnSale == true && modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else
                {
                    searchList = cars.Where(x => modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
            }

            searchList2 = searchList;

            if (!string.IsNullOrEmpty(parameters.MinPrice) || !string.IsNullOrEmpty(parameters.MaxPrice))
            {
                int resultMinPrice;
                int.TryParse(parameters.MinPrice, out resultMinPrice);
                int resultMaxPrice;
                int.TryParse(parameters.MaxPrice, out resultMaxPrice);
                searchList = searchList2.Where(x => x.SalePrice >= resultMinPrice && x.SalePrice <= resultMaxPrice).ToList();
            }

            if (parameters.MinYear != "Any" && parameters.MaxYear != "Any")
            {
                int resultMinYear;
                int.TryParse(parameters.MinYear, out resultMinYear);
                int resultMaxYear;
                int.TryParse(parameters.MaxYear, out resultMaxYear);

                searchList = searchList2.Where(x => x.Year >= resultMinYear && x.Year <= resultMaxYear).ToList();
            }

            if (parameters.MinYear != "Any" && parameters.MaxYear == "Any")
            {
                int resultMinYear;
                int.TryParse(parameters.MinYear, out resultMinYear);

                searchList = searchList2.Where(x => x.Year >= resultMinYear).ToList();
            }

            if (parameters.MinYear == "Any" && parameters.MaxYear != "Any")
            {
                int resultMaxYear;
                int.TryParse(parameters.MaxYear, out resultMaxYear);

                searchList = searchList2.Where(x => x.Year <= resultMaxYear).ToList();
            }

            List<Car> carsSearched = new List<Car>();

            foreach (var car in searchList)
            {
                car.Model = new Model();
                car.Model.ModelID = car.ModelID;
                car.Model.ModelName = modelRepo.GetModelById(car.ModelID).ModelName;
                car.Make = new Make();
                car.Make.MakeID = car.MakeID;
                car.Make.MakeName = makesRepo.GetMakeById(car.MakeID).MakeName;
                car.BodyStyle = new BodyStyle();
                car.BodyStyle.BodyStyleID = car.BodyStyleID;
                car.BodyStyle.BodyStyleName = bodyStylesRepo.GetBodyStyleById(car.BodyStyleID).BodyStyleName;
                car.Transmission = new Transmission();
                car.Transmission.TransmissionID = car.TransmissionID;
                car.Transmission.TransmissionType = transmissionsRepo.GetTransmissionById(car.TransmissionID).TransmissionType;
                car.ExteriorColor = new ExteriorColor();
                car.ExteriorColor.ExteriorColorID = car.ExteriorColorID;
                car.ExteriorColor.Color = extColorsRepo.GetExteriorColorById(car.ExteriorColorID).Color;
                car.InteriorColor = new InteriorColor();
                car.InteriorColor.InteriorColorID = car.InteriorColorID;
                car.InteriorColor.Color = intColorsRepo.GetInteriorColorById(car.InteriorColorID).Color;
                carsSearched.Add(car);
            }

            return carsSearched;
        }
        
        public void UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}