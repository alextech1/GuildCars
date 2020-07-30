using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class ConditionRepositoryEF : IConditionRepository
    {
        private readonly ApplicationDbContext _context;

        public ConditionRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public ConditionRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public Condition GetConditionById(int? id)
        {
            return _context.Conditions.Find(id);
        }

        public List<Condition> GetConditions()
        {
            return _context.Conditions.ToList();
        }

        public void InsertCondition(Condition condition)
        {
            _context.Conditions.Add(condition);
            _context.SaveChanges();
        }
    }
}