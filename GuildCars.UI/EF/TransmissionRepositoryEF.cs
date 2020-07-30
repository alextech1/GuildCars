using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class TransmissionRepositoryEF : ITransmissionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransmissionRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public TransmissionRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public Transmission GetTransmissionById(int? id)
        {
            return _context.Transmissions.Find(id);
        }

        public List<Transmission> GetTransmissions()
        {
            return _context.Transmissions.ToList();
        }

        public void InsertTransmission(Transmission transmission)
        {
            _context.Transmissions.Add(transmission);
            _context.SaveChanges();
        }
    }
}