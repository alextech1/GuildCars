using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.EF;
using GuildCars.UI.Factories;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ReportsController() { }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            List<User> allUsers;
            List<Transaction> allTransactions;

            var usersRepo = UserFactory.GetRepository();
            var transactionsRepo = TransactionFactory.GetRepository();
            allUsers = usersRepo.GetUsers();
            allTransactions = transactionsRepo.GetTransactions();

            var purchasedUsers = from user in allUsers
                                 join userTrans in allTransactions on user.Id equals userTrans.UserID
                                 group user by user.Id into idGrp
                                 select idGrp;

            List<UserListViewModel> userListView = purchasedUsers.Select(x => new UserListViewModel
            {
                UserID = x.Key,
                UserName = allTransactions.Where(y => y.UserID == x.Key).Select(y => $"{y.FirstName} {y.LastName}").FirstOrDefault()
            }).ToList();

            UserListViewModel initItem = new UserListViewModel();
            initItem.UserID = "Any";
            initItem.UserName = "-Any-";
            //userListView.Insert(0, initItem);

            LinkedList<UserListViewModel> userLinkedList = new LinkedList<UserListViewModel>(userListView);
            userLinkedList.AddFirst(initItem);

            var reportsList = purchasedUsers.Select(x => new ReportsViewModel
            {
                User = allTransactions.Where(y => y.UserID == x.Key).Select(y => $"{y.FirstName} {y.LastName}").FirstOrDefault(),
                TotalSales = allTransactions.Where(y => y.UserID == x.Key).Sum(y => y.PurchasePrice).ToString(),
                TotalVehicles = allTransactions.Where(y => y.UserID == x.Key).Count().ToString()
            }).ToList();


            ReportsViewModel reportsVM = new ReportsViewModel
            {
                Users = userLinkedList,
                Reports = reportsList
            };

            return View(reportsVM);
        }

        public ActionResult Inventory()
        {
            if (ModelState.IsValid)
            {
                InventoryViewModel inventoryViewModel = new InventoryViewModel();

                var inventoryRepo = GuildRepositoryFactory.GetRepository();
                var makesRepo = MakeFactory.GetRepository();
                var modelRepo = ModelFactory.GetRepository();

                List<Car> carList = inventoryRepo.GetAllCars();
                List<Car> newCarList = carList.Where(x => x.Mileage == "New").ToList();

                List<InventoryViewModel> newGroupCars = newCarList.GroupBy(x =>
                                (x.Year, makesRepo.GetMakeById(x.MakeID).MakeName, modelRepo.GetModelById(x.ModelID).ModelName))
                                .Select(b =>
                                new InventoryViewModel
                                {
                                    Year = b.Key.Year.ToString(),
                                    Make = b.Key.MakeName,
                                    Model = b.Key.ModelName,
                                    Count = b.Count(),
                                    StockValue = b.Sum(bn => bn.SalePrice).ToString()
                                }).ToList();

                var usedCarList = carList.Where(x => x.Mileage != "New").ToList();
                List<InventoryViewModel> usedGroupCars = usedCarList.GroupBy(x =>
                                (x.Year, makesRepo.GetMakeById(x.MakeID).MakeName, modelRepo.GetModelById(x.ModelID).ModelName))
                                .Select(b =>
                                new InventoryViewModel
                                {
                                    Year = b.Key.Year.ToString(),
                                    Make = b.Key.MakeName,
                                    Model = b.Key.ModelName,
                                    Count = b.Count(),
                                    StockValue = b.Select(bn => bn.SalePrice).Count().ToString()
                                }).ToList();
                var model = new GroupedInventoryViewModel { NewVehicles = newGroupCars, UsedVehicles = usedGroupCars };

                return View(model);
            }

            return View();
        }

    }
}
