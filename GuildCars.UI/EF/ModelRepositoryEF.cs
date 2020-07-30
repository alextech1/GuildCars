using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class ModelRepositoryEF : IModelRepository
    {
        private readonly ApplicationDbContext _context;

        public ModelRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public ModelRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public Model GetModelById(int? id)
        {
            return _context.Models.Find(id);
        }

        public List<Model> GetModels()
        {
            return _context.Models.ToList();
        }

        public void InsertModel(Model model)
        {
            _context.Models.Add(model);
            _context.SaveChanges();
        }
    }
}