using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class ExteriorColorRepositoryEF : IExteriorColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ExteriorColorRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public ExteriorColorRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public ExteriorColor GetExteriorColorById(int? id)
        {
            return _context.ExteriorColors.Find(id);
        }

        public List<ExteriorColor> GetExteriorColors()
        {
            return _context.ExteriorColors.ToList();
        }

        public void InsertExteriorColor(ExteriorColor exteriorColor)
        {
            _context.ExteriorColors.Add(exteriorColor);
            _context.SaveChanges();
        }
    }
}