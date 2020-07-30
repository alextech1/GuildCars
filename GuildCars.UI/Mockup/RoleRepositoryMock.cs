using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Mockup
{
    public class RoleRepositoryMock : IRoleRepository
    {
        private static List<GuildRole> roles = new List<GuildRole>()
        {
            new GuildRole { RoleID = 1, RoleName = "Sales"},
            new GuildRole { RoleID = 2, RoleName = "Admin"}
        };

        public GuildRole GetRoleById(int? id)
        {
            return roles.FirstOrDefault(x => x.RoleID == id);
        }

        public List<GuildRole> GetRoles()
        {
            return roles;
        }
    }
}
