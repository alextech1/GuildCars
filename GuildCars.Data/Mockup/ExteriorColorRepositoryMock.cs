using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mockup
{
    public class ExteriorColorRepositoryMock : IExteriorColorRepository
    {
        private static List<ExteriorColor> exteriorColors = new List<ExteriorColor>
        {
            new ExteriorColor { ExteriorColorID = 1, Color = "Blue" },
            new ExteriorColor { ExteriorColorID = 2, Color = "Black" },
            new ExteriorColor { ExteriorColorID = 3, Color = "White" },
            new ExteriorColor { ExteriorColorID = 4, Color = "Red" },
            new ExteriorColor { ExteriorColorID = 5, Color = "Orange" },
            new ExteriorColor { ExteriorColorID = 6, Color = "Green" }
        };

        public ExteriorColor GetExteriorColorById(int? id)
        {
            return exteriorColors.FirstOrDefault(x => x.ExteriorColorID == id);
        }

        public List<ExteriorColor> GetExteriorColors()
        {
            return exteriorColors;
        }
    }
}
