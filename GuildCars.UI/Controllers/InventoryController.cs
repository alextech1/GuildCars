using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Models;
using GuildCars.Models.Entity;
using GuildCars.UI.EF;
using GuildCars.UI.Factories;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Used()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Search()
        {
            CarViewModel carViewModel = new CarViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();

            var carList = carRepo.GetAllCars();

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarID = x.CarID,
                Year = x.Year,
                MakeName = x.Make.MakeName,
                ModelName = x.Model.ModelName,
                BodyStyleName = x.BodyStyle.BodyStyleName,
                TransmissionType = x.Transmission.TransmissionType,
                ExteriorColorName = x.ExteriorColor.Color,
                InteriorColorName = x.InteriorColor.Color,
                Mileage = x.Mileage,
                VIN = x.VIN,
                SalePrice = x.SalePrice,
                MSRP = x.MSRP,
                ImageFileName = x.Photo
            }).ToList();

            return View(carVMList);
        }

        public ActionResult Details(int id)
        {
            CarViewModel carViewModel = new CarViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();
            var makesRepo = MakeFactory.GetRepository();
            var modelRepo = ModelFactory.GetRepository();
            var typesRepo = ConditionFactory.GetRepository();
            var bodyStylesRepo = BodyStyleFactory.GetRepository();
            var transmissionsRepo = TransmissionFactory.GetRepository();
            var extColorsRepo = ExteriorColorFactory.GetRepository();
            var intColorsRepo = InteriorColorFactory.GetRepository();
            var transactionRepo = TransactionFactory.GetRepository();

            var carsInStock = carRepo.GetAllCars();

            var isInStock = carsInStock.Where(x => x.CarID == id).Select(x => x.IsInStock).FirstOrDefault();

            if (isInStock)
            {
                carViewModel.IsBought = true;
            }

            var carvm = carRepo.GetCarById(id);

            carViewModel.CarID = carvm.CarID;
            carViewModel.Year = carvm.Year;
            carViewModel.Make = new Make();
            carViewModel.Make.MakeID = carvm.MakeID;
            carViewModel.MakeName = makesRepo.GetMakeById(carvm.MakeID).MakeName;
            carViewModel.Model = new Model();
            carViewModel.Model.ModelID = carvm.ModelID;
            carViewModel.ModelName = modelRepo.GetModelById(carvm.ModelID).ModelName;
            carViewModel.BodyStyle = new BodyStyle();
            carViewModel.BodyStyleID = carvm.BodyStyleID;
            carViewModel.BodyStyleName = bodyStylesRepo.GetBodyStyleById(carvm.BodyStyleID).BodyStyleName;
            carViewModel.Transmission = new Transmission();
            carViewModel.TransmissionID = carvm.TransmissionID;
            carViewModel.TransmissionType = transmissionsRepo.GetTransmissionById(carvm.TransmissionID).TransmissionType;
            carViewModel.ExteriorColor = new ExteriorColor();
            carViewModel.ExteriorColorID = carvm.ExteriorColorID;
            carViewModel.ExteriorColorName = extColorsRepo.GetExteriorColorById(carvm.ExteriorColorID).Color;
            carViewModel.InteriorColor = new InteriorColor();
            carViewModel.InteriorColorID = carvm.InteriorColorID;
            carViewModel.InteriorColorName = intColorsRepo.GetInteriorColorById(carvm.InteriorColorID).Color;
            carViewModel.Mileage = carvm.Mileage;
            carViewModel.VIN = carvm.VIN;
            carViewModel.SalePrice = carvm.SalePrice;
            carViewModel.MSRP = carvm.MSRP;
            carViewModel.ImageFileName = carvm.Photo;
            carViewModel.Description = carvm.Description;


            return View(carViewModel);
        }
    }


}