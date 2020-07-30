using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class TransactionRepositoryEF : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public TransactionRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public Transaction GetTransactionById(int? id)
        {
            return _context.Transactions.Find(id);
        }

        public List<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }

        public void InsertTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}