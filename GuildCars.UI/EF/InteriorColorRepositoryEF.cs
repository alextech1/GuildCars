using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class InteriorColorRepositoryEF : IInteriorColorRepository
    {
        private readonly ApplicationDbContext _context;

        public InteriorColorRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public InteriorColorRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }


        public InteriorColor GetInteriorColorById(int? id)
        {
            return _context.InteriorColors.Find(id);
        }

        public List<InteriorColor> GetInteriorColors()
        {
            return _context.InteriorColors.ToList();
        }

        public void InsertInteriorColor(InteriorColor interiorColor)
        {
            _context.InteriorColors.Add(interiorColor);
            _context.SaveChanges();
        }
    }
}