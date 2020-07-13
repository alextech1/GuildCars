using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class InteriorColorRepositoryMock : IInteriorColorRepository
    {
        private static List<InteriorColor> interiorColors = new List<InteriorColor>
        {
            new InteriorColor { InteriorColorID = 1, Color = "Blue" },
            new InteriorColor { InteriorColorID = 2, Color = "Black" },
            new InteriorColor { InteriorColorID = 3, Color = "White" },
            new InteriorColor { InteriorColorID = 4, Color = "Red" },
            new InteriorColor { InteriorColorID = 5, Color = "Orange" },
            new InteriorColor { InteriorColorID = 6, Color = "Green" }
        };

        public InteriorColor GetInteriorColorById(int? id)
        {
            return interiorColors.FirstOrDefault(x => x.InteriorColorID == id);
        }

        public List<InteriorColor> GetInteriorColors()
        {
            return interiorColors;
        }
    }
}
