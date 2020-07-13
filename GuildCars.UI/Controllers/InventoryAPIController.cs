using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

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
    }
}