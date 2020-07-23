using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Mockup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
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
                //case "EF":
                //    return new GuildRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}
