using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class RoleRepositoryMock : IRoleRepository
    {
        private static List<Role> roles = new List<Role>()
        {
            new Role { RoleID = 1, RoleName = "Sales"},
            new Role { RoleID = 2, RoleName = "Admin"}
        };

        public Role GetRoleById(int? id)
        {
            return roles.FirstOrDefault(x => x.RoleID == id);
        }

        public List<Role> GetRoles()
        {
            return roles;
        }
    }
}
