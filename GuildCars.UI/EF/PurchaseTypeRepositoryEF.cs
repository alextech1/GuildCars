using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class PurchaseTypeRepositoryEF : IPurchaseTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseTypeRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public PurchaseTypeRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public PurchaseType GetPurchaseTypeById(int? id)
        {
            return _context.PurchaseTypes.Find(id);
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            return _context.PurchaseTypes.ToList();
        }
    }
}