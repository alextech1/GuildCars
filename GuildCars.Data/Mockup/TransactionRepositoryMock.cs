﻿using GuildCars.Data.Interfaces;
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
