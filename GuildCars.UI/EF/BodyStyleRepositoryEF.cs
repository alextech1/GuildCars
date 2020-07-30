using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class BodyStyleRepositoryEF : IBodyStyleRepository
    {
        private readonly ApplicationDbContext _context;

        public BodyStyleRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public BodyStyleRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public BodyStyle GetBodyStyleById(int? id)
        {
            return _context.BodyStyles.Find(id);
        }

        public List<BodyStyle> GetBodyStyles()
        {
            return _context.BodyStyles.ToList();
        }

        public void InsertBodyStyle(BodyStyle bodyStyle)
        {
            _context.BodyStyles.Add(bodyStyle);
            _context.SaveChanges();
        }
    }
}