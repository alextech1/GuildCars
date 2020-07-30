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
    public static class ExteriorColorFactory
    {
        public static IExteriorColorRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new ExteriorColorRepositoryMock();
                case "ADO":
                    return new ExteriorColorRepositoryADO();
                case "EF":
                    return new ExteriorColorRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}