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
    public static class BodyStyleFactory
    {
        public static IBodyStyleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new BodyStyleRepositoryMock();
                case "ADO":
                    return new BodyStyleRepositoryADO();
                case "EF":
                    return new BodyStyleRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}