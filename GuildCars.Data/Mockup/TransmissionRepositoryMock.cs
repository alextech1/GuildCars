using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class TransmissionRepositoryMock : ITransmissionRepository
    {
        private static List<Transmission> transmissions = new List<Transmission>
        {
            new Transmission { TransmissionID = 1, TransmissionType = "Automatic" },
            new Transmission { TransmissionID = 2, TransmissionType = "Manual" }
        };

        public Transmission GetTransmissionById(int? id)
        {
            return transmissions.FirstOrDefault(x => x.TransmissionID == id);
        }

        public List<Transmission> GetTransmissions()
        {
            return transmissions;
        }
    }
}
