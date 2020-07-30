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
    public static class InteriorColorFactory
    {
        public static IInteriorColorRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new InteriorColorRepositoryMock();
                case "ADO":
                    return new InteriorColorRepositoryADO();
                case "EF":
                    return new InteriorColorRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}