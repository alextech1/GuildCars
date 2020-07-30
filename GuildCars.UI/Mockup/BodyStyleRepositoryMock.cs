using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Mockup
{
    public class BodyStyleRepositoryMock : IBodyStyleRepository
    {
        private static List<BodyStyle> bodyStyles = new List<BodyStyle>
        {
            new BodyStyle { BodyStyleID = 1, BodyStyleName = "Car" },
            new BodyStyle { BodyStyleID = 2, BodyStyleName = "Truck" },
            new BodyStyle { BodyStyleID = 3, BodyStyleName = "SUV" },
            new BodyStyle { BodyStyleID = 4, BodyStyleName = "Coupe" },
            new BodyStyle { BodyStyleID = 5, BodyStyleName = "Sedan" }
        };

        public BodyStyle GetBodyStyleById(int? id)
        {
            return bodyStyles.FirstOrDefault(x => x.BodyStyleID == id);
        }

        public List<BodyStyle> GetBodyStyles()
        {
            return bodyStyles;
        }

        public void InsertBodyStyle(BodyStyle bodyStyle)
        {
            throw new NotImplementedException();
        }
    }
}
