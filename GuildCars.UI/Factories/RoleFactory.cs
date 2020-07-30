using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.UI.Mockup;
using GuildCars.UI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Factories
{
    public static class RoleFactory
    {
        public static IRoleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new RoleRepositoryMock();
                case "ADO":
                    return new RoleRepositoryADO();
                case "EF":
                    return new RoleRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}