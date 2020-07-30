using GuildCars.Models.Entity;
using GuildCars.UI.Factories;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public SalesController() { }

        public ActionResult Index()
        {
            CarViewModel carViewModel = new CarViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();

            return View();
        }

        [Authorize]
        public ActionResult Purchase(int id) 
        {
            var model = new PurchaseViewModel();

            var purchaseTypeRepo = PurchaseTypeFactory.GetRepository();
            var statesRepo = StateFactory.GetRepository();

            model.Transaction = new Transaction();
            model.Transaction.CarID = id;

            PurchaseViewModel viewModel = new PurchaseViewModel
            {
                CarID = model.Transaction.CarID,
                States = statesRepo.GetStates(),
                PurchaseTypes = purchaseTypeRepo.GetPurchaseTypes()                
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            var stateId = model.Transaction.StateID;
            var purchaseId = model.Transaction.PurchaseTypeID;

            if (ModelState.IsValid)
            {
                var purchaseTypeRepo = PurchaseTypeFactory.GetRepository();
                var transactionRepo = TransactionFactory.GetRepository();
                var statesRepo = StateFactory.GetRepository();

                try
                {
                    model.Transaction.State = new State();
                    model.Transaction.State.StateID = stateId;
                    model.Transaction.State.StateName = statesRepo.GetStateById(model.Transaction.StateID).StateName;
                    model.Transaction.PurchaseType = new PurchaseType();
                    model.Transaction.PurchaseType.PurchaseTypeID = purchaseId;
                    model.Transaction.PurchaseType.PurchaseTypeName = purchaseTypeRepo.GetPurchaseTypeById(model.Transaction.PurchaseTypeID).PurchaseTypeName;
                    model.Transaction = new Transaction();
                    model.Transaction.UserID = AuthorizeUtilities.GetUserId(this);
                    model.Transaction.StateID = stateId;
                    model.Transaction.PurchaseTypeID = purchaseId;
                    model.Transaction.AddressStreet1 = model.AddressStreet1;
                    model.Transaction.AddressStreet2 = model.AddressStreet2;
                    model.Transaction.CarID = model.CarID;
                    model.Transaction.City = model.City;
                    model.Transaction.Email = model.Email;
                    model.Transaction.FirstName = model.FirstName;
                    model.Transaction.LastName = model.LastName;
                    model.Transaction.PurchasePrice = model.PurchasePrice;
                    model.Transaction.PurchaseDate = DateTime.Now.ToString("MM/dd/yyyy");
                    model.Transaction.Role = model.Role;
                    model.Transaction.ZipCode = model.ZipCode;

                    transactionRepo.InsertTransaction(model.Transaction);

                    /*_context.Transactions.Add(model.Transaction);

                    if (model.Transaction == null)
                        model.Transaction = new Transaction();

                    _context.SaveChanges();*/

                    return RedirectToAction("");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                return View(model);
        }
    }
}