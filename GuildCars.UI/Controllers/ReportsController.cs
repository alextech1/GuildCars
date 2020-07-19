using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Sales()
        {
            var allUsers = _context.Users.ToList();
            var allTransactions = _context.Transactions.ToList();

            var purchasedUsers = from user in allUsers
                                 join userTrans in allTransactions on user.Id equals userTrans.UserID
                                 group user by user.Id into idGrp
                                 select idGrp;

            var reportsVM = purchasedUsers.Select(x => new ReportsViewModel
            {
                User = allTransactions.Where(y => y.UserID == x.Key).Select(y => $"{y.FirstName} {y.LastName}").FirstOrDefault(),
                TotalSales = allTransactions.Where(y => y.UserID  == x.Key).Sum(y => y.PurchasePrice).ToString(),
                TotalVehicles = allTransactions.Where(y => y.UserID == x.Key).Count().ToString()
            }).ToList();

            return View(reportsVM);
        }

    }
}