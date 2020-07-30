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
    public static class GuildRepositoryFactory
    {
        public static IGuildRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new GuildRepositoryMock();
                case "ADO":
                    return new GuildRepositoryADO();
                case "EF":
                    return new GuildRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}