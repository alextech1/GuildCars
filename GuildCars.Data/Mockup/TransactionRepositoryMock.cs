using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class TransactionRepositoryMock : ITransactionRepository
    {
        private static List<Transaction> transactions = new List<Transaction>
        {
            new Transaction { TransactionID = 1, AddressStreet1 = "101 n hill", AddressStreet2 = "",
            Car = new Car { CarID = 1 }, City = "Dallas", Email = "boston@gmail.com", FirstName = "Albert",
            LastName = "Stone", Phone = "214-223-4455", PurchasePrice = 12300.00m, 
            PurchaseType = new PurchaseType { PurchaseTypeID = 1 },
            Role = "Sales", State = new State { StateID = 1}, ZipCode = 76108
            }
        };

        public Transaction GetTransactionById(int? id)
        {
            return transactions.FirstOrDefault(x => x.TransactionID == id);
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}
