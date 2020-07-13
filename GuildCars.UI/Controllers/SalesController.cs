using GuildCars.Data.Factories;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        public ActionResult Index()
        {
            CarViewModel carViewModel = new CarViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();

            /*carViewModel.Cars = carRepo.GetAllCars();

            var carList = carViewModel.Cars;

            List<CarViewModel> onSaleCarList = carList.Select(x => new CarViewModel
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
            }).ToList();*/

            return View();
        }

        public ActionResult Purchase(int id) 
        {
            var model = new PurchaseViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();
            var makesRepo = MakeFactory.GetRepository();
            var modelRepo = ModelFactory.GetRepository();
            var typesRepo = ConditionFactory.GetRepository();
            var bodyStylesRepo = BodyStyleFactory.GetRepository();
            var transmissionsRepo = TransmissionFactory.GetRepository();
            var extColorsRepo = ExteriorColorFactory.GetRepository();
            var intColorsRepo = InteriorColorFactory.GetRepository();
            var purchaseTypeRepo = PurchaseTypeFactory.GetRepository();
            var transactionRepo = TransactionFactory.GetRepository();
            var statesRepo = StateFactory.GetRepository();

            model.Transaction = new Transaction();

            PurchaseViewModel viewModel = new PurchaseViewModel
            {
                Transaction = transactionRepo.GetTransactionById(id),
                FirstName = model.Transaction.FirstName,
                LastName = model.Transaction.LastName,
                Phone = model.Transaction.Phone,
                Email = model.Transaction.Email,
                AddressStreet1 = model.Transaction.AddressStreet1,
                AddressStreet2 = model.Transaction.AddressStreet2,
                City = model.Transaction.City,
                States = statesRepo.GetStates(),
                StatesID = model.Transaction.StateID,
                ZipCode = model.Transaction.ZipCode,
                PurchasePrice = model.Transaction.PurchasePrice,
                PurchaseTypes = purchaseTypeRepo.GetPurchaseTypes(),
                PurchaseTypesID = model.Transaction.PurchaseTypeID            
            };

            return View(viewModel);
        }
    }
}