using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class MakeRepositoryEF : IMakeRepository
    {
        private readonly ApplicationDbContext _context;

        public MakeRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public MakeRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }


        public Make GetMakeById(int? id)
        {
            return _context.Makes.Find(id);
        }

        public List<Make> GetMakes()
        {
            return _context.Makes.ToList();
        }

        public void InsertMake(Make make)
        {
            _context.Makes.Add(make);
            _context.SaveChanges();
        }
    }
}