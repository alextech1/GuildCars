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
    public static class TransmissionFactory
    {
        public static ITransmissionRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new TransmissionRepositoryMock();
                case "ADO":
                    return new TransmissionRepositoryADO();
                case "EF":
                    return new TransmissionRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}