using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class StateRepositoryEF : IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public StateRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public State GetStateById(int? id)
        {
            return _context.States.Find(id);
        }

        public List<State> GetStates()
        {
            return _context.States.ToList();
        }
    }
}