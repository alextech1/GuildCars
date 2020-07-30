using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class RoleRepositoryEF : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public RoleRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public GuildRole GetRoleById(int? id)
        {
            return _context.GuildRoles.Find(id);
        }

        public List<GuildRole> GetRoles()
        {
            return _context.GuildRoles.ToList();
        }
    }
}