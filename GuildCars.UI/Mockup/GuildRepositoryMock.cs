using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using GuildCars.UI.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Mockup
{
    public class GuildRepositoryMock : IGuildRepository
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { CarID = 1, OnSale = true, IsInStock = true, MakeID = 1, ModelID = 1, ConditionID = 2,
                Year = 2010, BodyStyleID = 1, TransmissionID = 2, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4THG", SalePrice = 9000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019",
                Photo = "hondacivic.png"
            },
            new Car { CarID = 2, OnSale = true, IsInStock = true, MakeID = 1, ModelID = 6, ConditionID = 2,
                Year = 2012, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH9", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/05/2019",
                Photo = "hondaaccord.jpg"
            },
            new Car { CarID = 3, OnSale = false, IsInStock = true, MakeID = 2, ModelID = 2, ConditionID = 2,
                Year = 2009, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH8", SalePrice = 8000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/06/2019",
                Photo = "toyotacorolla.png"
            },
            new Car { CarID = 4, OnSale = false, IsInStock = true, MakeID = 2, ModelID = 2, ConditionID = 2,
                Year = 2010, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH7", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/06/2019",
                Photo = "toyotacorolla.png"
            },
            new Car { CarID = 5, OnSale = true, IsInStock = true, MakeID = 1, ModelID = 1, ConditionID = 2,
                Year = 2015, BodyStyleID = 1, TransmissionID = 2, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH6", SalePrice = 11000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/08/2019",
                Photo = "hondacivic.png"
            },
            new Car { CarID = 6,  OnSale = false, IsInStock = false, MakeID = 1, ModelID = 6, ConditionID = 1,
                Year = 2009, BodyStyleID = 1, TransmissionID = 2, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J4FO4099", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "02/09/2019",
                Photo = "hondaaccord.jpg"
            },
            new Car { CarID = 7, OnSale = false, IsInStock = false, MakeID = 1,ModelID = 6,ConditionID = 1,
                Year = 2010, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 2, InteriorColorID = 1,
                Mileage = "New", VIN = "1ASDFOJ29J4FO43ER", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "03/06/2019",
                Photo = "hondaaccord.jpg"
            },
            new Car { CarID = 8, OnSale = true, IsInStock = true, MakeID = 1, ModelID = 1, ConditionID = 1,
                Year = 2015, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J4FOD493", SalePrice = 9000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "04/10/2019",
                Photo = "hondacivic.png"
            },
            new Car { CarID = 9, OnSale = true, IsInStock = true, MakeID = 1, ModelID = 1, ConditionID = 1,
                Year = 2015, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J4FORE9A", SalePrice = 13000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "05/07/2019",
                Photo = "hondacivic.png"
            },
            new Car { CarID = 10, OnSale = true, IsInStock = true, MakeID = 2, ModelID = 7, ConditionID = 1,
                Year = 2015, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "06/14/2019",
                Photo = "toyotarav4.png"
            },
            new Car { CarID = 11, OnSale = true, IsInStock = true, MakeID = 3, ModelID = 8, ConditionID = 1,
                Year = 2016, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "07/19/2019",
                Photo = "volkswagengolf.png"
            },
            new Car { CarID = 12, OnSale = true, IsInStock = true, MakeID = 3, ModelID = 3, ConditionID = 1,
                Year = 2016, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "07/21/2019",
                Photo = "volkswagenjetta.png"
            },
            new Car { CarID = 13, OnSale = true, IsInStock = true, MakeID = 2, ModelID = 7, ConditionID = 1,
                Year = 2016, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "07/23/2019",
                Photo = "nissansentra.png"
            },
            new Car { CarID = 14, OnSale = true, IsInStock = true, MakeID = 5, ModelID = 10, ConditionID = 1,
                Year = 2017, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "08/15/2019",
                Photo = "nissanaltima.jpg"
            },
            new Car { CarID = 15, OnSale = true, IsInStock = true, MakeID = 4, ModelID = 4, ConditionID = 1,
                Year = 2018, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "09/10/2019",
                Photo = "bmw840.jpg"
            },
            new Car { CarID = 16, OnSale = true, IsInStock = true, MakeID = 4, ModelID = 9, ConditionID = 1,
                Year = 2018, BodyStyleID = 1, TransmissionID = 1, ExteriorColorID = 1, InteriorColorID = 2,
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 12000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "10/05/2019",
                Photo = "bmwm8.jpg"
            }


        };

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public Car GetCarById(int? id)
        {
            return cars.FirstOrDefault(x => x.CarID == id);
        }

        public void InsertCar(Car car)
        {
            var newCarID = cars.Max(x => x.CarID) + 1;
            car.CarID = newCarID;
            cars.Add(car);
        }

        public IEnumerable<Car> Search(ListingSearchParameters parameters)
        {
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
                    searchList = cars.Where(x => x.Mileage != "New" && makesRepo.GetMakeById(x.MakeID).MakeName.Contains(parameters.Make.ToLower())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.Mileage == "New" && makesRepo.GetMakeById(x.MakeID).MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
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
                    searchList = cars.Where(x => x.Mileage != "New" && modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.Mileage == "New" && modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else if (parameters.OnSale == "true")
                {
                    searchList = cars.Where(x => x.OnSale == true && modelRepo.GetModelById(x.ModelID).ModelName.ToLower().Contains(parameters.Make.ToLower())).ToList();
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
            Car carUpdate = GetCarById(car.CarID);
            carUpdate.OnSale = car.OnSale;
            carUpdate.IsInStock = car.IsInStock;
            carUpdate.Make = car.Make;
            carUpdate.Model = car.Model;
            carUpdate.Condition = car.Condition;
            carUpdate.Year = car.Year;
            carUpdate.BodyStyle = car.BodyStyle;
            carUpdate.Transmission = car.Transmission;
            carUpdate.ExteriorColor = car.ExteriorColor;
            carUpdate.InteriorColor = car.InteriorColor;
            carUpdate.Mileage = car.Mileage;
            carUpdate.VIN = car.VIN;
            carUpdate.SalePrice = car.SalePrice;
            carUpdate.MSRP = car.MSRP;
            carUpdate.Description = car.Description;
            carUpdate.Photo = car.Photo;
        }

        public void DeleteCar(int id)
        {
            cars.RemoveAll(x => x.CarID == id);
        }
    }
}
