using GuildCars.Data.Factories;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
            var makesRepo = MakeFactory.GetRepository();
            var modelRepo = ModelFactory.GetRepository();
            var typesRepo = ConditionFactory.GetRepository();
            var bodyStylesRepo = BodyStyleFactory.GetRepository();
            var transmissionsRepo = TransmissionFactory.GetRepository();
            var extColorsRepo = ExteriorColorFactory.GetRepository();
            var intColorsRepo = InteriorColorFactory.GetRepository();

            List<Car> carList = carRepo.GetAllCars();            

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarID = x.CarID,
                MakeID = x.MakeID,
                MakeName = makesRepo.GetMakeById(x.MakeID).MakeName,
                ModelID = x.ModelID,
                ModelName = modelRepo.GetModelById(x.ModelID).ModelName,
                Year = x.Year,
                MSRP = x.MSRP,
                SalePrice = x.SalePrice,
                ImageFileName = x.Photo
            }).ToList();

            /*foreach (var car in carList)
            {
            }*/

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