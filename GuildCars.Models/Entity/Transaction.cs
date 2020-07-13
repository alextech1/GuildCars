using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Entity
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int? TransactionID { get; set; }
        public int? CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }               
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string AddressStreet1 { get; set; }
        public string AddressStreet2 { get; set; }
        public string City { get; set; }
        public int? StateID { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        public List<State> States { get; set; }
        public int ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public int? PurchaseTypeID { get; set; }
        [ForeignKey("PurchaseTypeID")]
        public virtual PurchaseType PurchaseType { get; set; }
        public List<PurchaseType> PurchaseTypes { get; set; }
    }
}
