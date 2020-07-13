using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class PurchaseTypeRepositoryMock : IPurchaseTypeRepository
    {
        private static List<PurchaseType> purchaseTypes = new List<PurchaseType>
        {
            new PurchaseType { PurchaseTypeID = 1, PurchaseTypeName = "Bank Finance"},
            new PurchaseType { PurchaseTypeID = 2, PurchaseTypeName = "Cash"},
            new PurchaseType { PurchaseTypeID = 3, PurchaseTypeName = "Dealer Finance"}
        };

        public PurchaseType GetPurchaseTypeById(int? id)
        {
            return purchaseTypes.FirstOrDefault(x => x.PurchaseTypeID == id);
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            return purchaseTypes;
        }
    }
}
