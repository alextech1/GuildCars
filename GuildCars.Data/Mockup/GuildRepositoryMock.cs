using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class GuildRepositoryMock : IGuildRepository
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { CarID = 1, OnSale = true, IsInStock = true, Make = new Make 
            { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 1, ModelName = ModelFactory.GetRepository().GetModelById(1).ModelName },
                Condition = new Condition { ConditionID = 2, ConditionType = ConditionFactory.GetRepository().GetConditionById(2).ConditionType }, Year = 2010,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 2, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(2).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(1).Color },
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4THG", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondacivic.png"
            },
            new Car { CarID = 2, OnSale = true, IsInStock = true, Make = new Make 
            { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 6, ModelName = ModelFactory.GetRepository().GetModelById(6).ModelName },
                Condition = new Condition { ConditionID = 2, ConditionType = ConditionFactory.GetRepository().GetConditionById(2).ConditionType }, Year = 2012,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(1).Color },
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH9", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondaaccord.jpg"
            },
            new Car { CarID = 3, OnSale = false, IsInStock = true, Make = new Make { MakeID = 2, MakeName = MakeFactory.GetRepository().GetMakeById(2).MakeName },
                Model = new Model { ModelID = 2, ModelName = ModelFactory.GetRepository().GetModelById(6).ModelName },
                Condition = new Condition { ConditionID = 2, ConditionType = ConditionFactory.GetRepository().GetConditionById(2).ConditionType }, Year = 2009,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH8", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "toyotacorolla.png"
            },
            new Car { CarID = 4, OnSale = false, IsInStock = true, Make = new Make { MakeID = 2, MakeName = MakeFactory.GetRepository().GetMakeById(2).MakeName },
                Model = new Model { ModelID = 2, ModelName = ModelFactory.GetRepository().GetModelById(6).ModelName },
                Condition = new Condition { ConditionID = 2, ConditionType = ConditionFactory.GetRepository().GetConditionById(2).ConditionType }, Year = 2010,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH7", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "toyotacorolla.png"
            },
            new Car { CarID = 5, OnSale = true, IsInStock = true, Make = new Make { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 1, ModelName = ModelFactory.GetRepository().GetModelById(1).ModelName },
                Condition = new Condition { ConditionID = 2, ConditionType = ConditionFactory.GetRepository().GetConditionById(2).ConditionType }, Year = 2015,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "102,000", VIN = "1ASDFOJ29J4FO4TH6", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondacivic.png"
            },
            new Car { CarID = 6, OnSale = true, IsInStock = true, Make = new Make { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 6, ModelName = ModelFactory.GetRepository().GetModelById(6).ModelName },
                Condition = new Condition { ConditionID = 1, ConditionType = ConditionFactory.GetRepository().GetConditionById(1).ConditionType }, Year = 2009,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "New", VIN = "1ASDFOJ29J4FO4099", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondaaccord.jpg"
            },
            new Car { CarID = 7, OnSale = true, IsInStock = true, Make = new Make { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 6, ModelName = ModelFactory.GetRepository().GetModelById(6).ModelName },
                Condition = new Condition { ConditionID = 1, ConditionType = ConditionFactory.GetRepository().GetConditionById(1).ConditionType }, Year = 2010,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 2, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(2).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 1, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(1).Color },
                Mileage = "New", VIN = "1ASDFOJ29J4FO43ER", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondaaccord.jpg"
            },
            new Car { CarID = 8, OnSale = true, IsInStock = true, Make = new Make { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 1, ModelName = ModelFactory.GetRepository().GetModelById(1).ModelName },
                Condition = new Condition { ConditionID = 1, ConditionType = ConditionFactory.GetRepository().GetConditionById(1).ConditionType }, Year = 2015,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "New", VIN = "1ASDFOJ29J4FOD493", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondacivic.png"
            },
            new Car { CarID = 9, OnSale = true, IsInStock = true, Make = new Make { MakeID = 1, MakeName = MakeFactory.GetRepository().GetMakeById(1).MakeName },
                Model = new Model { ModelID = 1, ModelName = ModelFactory.GetRepository().GetModelById(1).ModelName },
                Condition = new Condition { ConditionID = 1, ConditionType = ConditionFactory.GetRepository().GetConditionById(1).ConditionType }, Year = 2015,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "New", VIN = "1ASDFOJ29J4FORE9A", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "hondacivic.png"
            },
            new Car { CarID = 10, OnSale = true, IsInStock = true, Make = new Make { MakeID = 2, MakeName = MakeFactory.GetRepository().GetMakeById(2).MakeName },
                Model = new Model { ModelID = 7, ModelName = ModelFactory.GetRepository().GetModelById(7).ModelName },
                Condition = new Condition { ConditionID = 1, ConditionType = ConditionFactory.GetRepository().GetConditionById(1).ConditionType }, Year = 2015,
                BodyStyle = new BodyStyle { BodyStyleID = 1, BodyStyleName = BodyStyleFactory.GetRepository().GetBodyStyleById(1).BodyStyleName },
                Transmission = new Transmission { TransmissionID = 1, TransmissionType = TransmissionFactory.GetRepository().GetTransmissionById(1).TransmissionType },
                ExteriorColor = new ExteriorColor { ExteriorColorID = 1, Color = ExteriorColorFactory.GetRepository().GetExteriorColorById(1).Color },
                InteriorColor = new InteriorColor { InteriorColorID = 2, Color = InteriorColorFactory.GetRepository().GetInteriorColorById(2).Color },
                Mileage = "New", VIN = "1ASDFOJ29J93FA231", SalePrice = 10000.00M, MSRP = 12000.00M,
                Description = "The best car in town, come check out this great deal today", DateAdded = "01/04/2019", Photo = "toyotarav4.png"
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

            if (!string.IsNullOrEmpty(parameters.Make))
            {
                if (parameters.Mileage == "used")
                {
                    searchList = cars.Where(x => x.Mileage != "New" && x.Make.MakeName.Contains(parameters.Make.ToLower())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.Mileage == "New" && x.Make.MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
                else if (parameters.OnSale == "true")
                {
                    searchList = cars.Where(x => x.OnSale == true && x.Make.MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
                else
                {
                    searchList = cars.Where(x => x.Make.MakeName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
            }

            if (!string.IsNullOrEmpty(parameters.Model))
            {
                if (parameters.Mileage == "used")
                {
                    searchList = cars.Where(x => x.Mileage != "New" && x.Model.ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.Mileage == "New" && x.Model.ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
                else if (parameters.OnSale == "true")
                {
                    searchList = cars.Where(x => x.OnSale == true && x.Model.ModelName.ToLower().Contains(parameters.Make.ToLower())).ToList();
                }
                else
                {
                    searchList = cars.Where(x => x.Model.ModelName.ToLower().Contains(parameters.Model.ToLower())).ToList();
                }
            }

            if (parameters.Year.HasValue)
            {
                if (parameters.Mileage == "used")
                {
                    searchList = cars.Where(x => x.Mileage != "New" && x.Year.ToString().Contains(parameters.Year.ToString())).ToList();
                }
                else if (parameters.Mileage == "new")
                {
                    searchList = cars.Where(x => x.Mileage == "New" && x.Year.ToString().Contains(parameters.Year.ToString())).ToList();
                }
                else if (parameters.OnSale == "true")
                {
                    searchList = cars.Where(x => x.OnSale == true && x.Year.ToString().Contains(parameters.Make.ToLower())).ToList();
                }
                else
                {
                    searchList = cars.Where(x => x.Year.ToString().Contains(parameters.Year.ToString())).ToList();
                }
            }

            return searchList;
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
