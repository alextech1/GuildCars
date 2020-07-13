using GuildCars.Data.Factories;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CarViewModel model = new CarViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();

            model.Cars = carRepo.GetAllCars();

            List<Car> carList = model.Cars;

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                MakeName = x.Make.MakeName,
                ModelName = x.Model.ModelName,
                Year = x.Year,
                MSRP = x.MSRP,
                SalePrice = x.SalePrice,
                ImageFileName = x.Photo
            }).ToList();

            return View(carVMList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /*public ActionResult Contact()
        {
            

            return View();
        }*/

        public ActionResult Contact(string vin)
        {
            var model = new ContactViewModel();

            ViewBag.Message = vin;

            return View();
        }

        public ActionResult Specials()
        {
            var model = new SpecialsViewModel();

            var specialsRepo = SpecialsFactory.GetRepository();

            model.SpecialsList = specialsRepo.GetSpecials();

            List<SpecialsViewModel> viewModel = model.SpecialsList.Select(x => new SpecialsViewModel
            {
                SpecialsID = x.SpecialsID,
                Title = x.Title,
                Description = x.Description,
                ImageFileName = x.ImageFileName
            }).ToList();

            return View(model);
        }

        
    }
}