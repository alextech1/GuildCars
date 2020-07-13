using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Used()
        {
            CarViewModel carViewModel = new CarViewModel();
            //ApplicationUser appUser = new ApplicationUser();

            carViewModel.IGuildRepository = GuildRepositoryFactory.GetRepository();

            carViewModel.Cars = carViewModel.IGuildRepository.GetAllCars();

            var carList = carViewModel.Cars;

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarVMID = x.CarID,
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
                ImageFileName = x.Photo,
                //Role = appUser.Role
            }).ToList();

            return View(carVMList);
        }

        public ActionResult New()
        {
            CarViewModel carViewModel = new CarViewModel();
            //ApplicationUser appUser = new ApplicationUser();

            carViewModel.IGuildRepository = GuildRepositoryFactory.GetRepository();

            carViewModel.Cars = carViewModel.IGuildRepository.GetAllCars();

            var carList = carViewModel.Cars;

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarVMID = x.CarID,
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
                ImageFileName = x.Photo,
                //Role = appUser.Role
            }).ToList();

            return View(carVMList);
        }

        public ActionResult Search()
        {
            CarViewModel carViewModel = new CarViewModel();

            carViewModel.IGuildRepository = GuildRepositoryFactory.GetRepository();

            carViewModel.Cars = carViewModel.IGuildRepository.GetAllCars();

            var carList = carViewModel.Cars;

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarVMID = x.CarID,
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

            carViewModel.IGuildRepository = GuildRepositoryFactory.GetRepository();

            var carvm = carViewModel.IGuildRepository.GetCarById(id);

            carViewModel.CarVMID = carvm.CarID;
            carViewModel.Year = carvm.Year;
            carViewModel.MakeName = carvm.Make.MakeName;
            carViewModel.ModelName = carvm.Model.ModelName;
            carViewModel.BodyStyleName = carvm.BodyStyle.BodyStyleName;
            carViewModel.TransmissionType = carvm.Transmission.TransmissionType;
            carViewModel.ExteriorColorName = carvm.ExteriorColor.Color;
            carViewModel.InteriorColorName = carvm.InteriorColor.Color;
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