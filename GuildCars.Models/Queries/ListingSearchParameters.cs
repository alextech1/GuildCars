using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class ListingSearchParameters
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string MinYear { get; set; }
        public string MaxYear { get; set; }
        public string Mileage { get; set; }
        public string OnSale { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}
