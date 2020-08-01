using GuildCars.Data;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using GuildCars.UI.Factories;
using GuildCars.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.WebPages;

namespace GuildCars.UI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    //[RoutePrefix("")]
    public class InventoryAPIController : ApiController
    {
        [Route("api/cars/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search([FromUri] ListingSearchParameters parameters)
        {
            var repo = GuildRepositoryFactory.GetRepository();

            try
            {
                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/cars/searchReport")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchReport([FromUri] ReportsSearchParameters parameters)
        {
            try
            {

                var usersRepo = UserFactory.GetRepository();
                var transactionsRepo = TransactionFactory.GetRepository();
                var allUsers = usersRepo.GetUsers();
                var allTransactions = transactionsRepo.GetTransactions();

                DateTime fromDate = (parameters.FromDate != "") ? Convert.ToDateTime(parameters.FromDate).Date : new DateTime();
                DateTime toDate = (parameters.ToDate != "") ? Convert.ToDateTime(parameters.ToDate).Date : new DateTime();

                IEnumerable<IGrouping<string, User>> purchasedUsers;

                if (parameters.User != "Any" && parameters.FromDate != null || parameters.ToDate != null)
                {
                    purchasedUsers = from user in allUsers
                                     join userTrans in allTransactions on user.Id equals userTrans.UserID
                                     where Convert.ToDateTime(userTrans.PurchaseDate).Date >= fromDate &&
                                     Convert.ToDateTime(userTrans.PurchaseDate).Date <= toDate &&
                                     userTrans.UserID == parameters.User
                                     group user by user.Id into idGrp
                                     select idGrp;
                }
                else if (parameters.User == "Any" && parameters.FromDate != null || parameters.ToDate != null)
                {
                    purchasedUsers = from user in allUsers
                                     join userTrans in allTransactions on user.Id equals userTrans.UserID
                                     where Convert.ToDateTime(userTrans.PurchaseDate).Date >= fromDate &&
                                     Convert.ToDateTime(userTrans.PurchaseDate).Date <= toDate
                                     group user by user.Id into idGrp
                                     select idGrp;
                }
                else
                {
                    purchasedUsers = from user in allUsers
                                     join userTrans in allTransactions on user.Id equals userTrans.UserID
                                     group user by user.Id into idGrp
                                     select idGrp;
                }

                var reportsVM = purchasedUsers.Select(x => new ReportsViewModel
                {
                    User = allTransactions.Where(y => y.UserID == x.Key).Select(y => $"{y.FirstName} {y.LastName}").FirstOrDefault(),
                    TotalSales = allTransactions.Where(y => y.UserID == x.Key).Sum(y => y.PurchasePrice).ToString(),
                    TotalVehicles = allTransactions.Where(y => y.UserID == x.Key).Count().ToString()
                }).ToList();

                return Ok(reportsVM);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
