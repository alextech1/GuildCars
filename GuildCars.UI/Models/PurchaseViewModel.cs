using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class PurchaseViewModel
    {
        public Transaction Transaction { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AddressStreet1 { get; set; }
        public string AddressStreet2 { get; set; }
        public string City { get; set; }
        public IEnumerable<State> States { get; set; }
        public int? StatesID { get; set; }
        public int? ZipCode { get; set; }
        public decimal? PurchasePrice { get; set; }
        public IEnumerable<PurchaseType> PurchaseTypes { get; set; }
        public int? PurchaseTypesID { get; set; }
    }
}