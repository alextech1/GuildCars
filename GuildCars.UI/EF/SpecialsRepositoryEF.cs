using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class SpecialsRepositoryEF : ISpecialsRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialsRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public SpecialsRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddSpecial(Specials specials)
        {
            _context.Specials.Add(specials);
            _context.SaveChanges();
        }

        public List<Specials> GetSpecials()
        {
            return _context.Specials.ToList();
        }

        public Specials GetSpecialsById(int? id)
        {
            return _context.Specials.Find(id);
        }

        public void RemoveSpecial(int? id)
        {
            Specials specials = _context.Specials.Find(id);
            _context.Specials.Remove(specials);
            _context.SaveChanges();
        }

        public void Update(Specials specials)
        {
            _context.Entry(specials).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}