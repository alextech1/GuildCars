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
    public static class ConditionFactory
    {
        public static IConditionRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new ConditionRepositoryMock();
                case "ADO":
                    return new ConditionRepositoryADO();
                case "EF":
                    return new ConditionRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}