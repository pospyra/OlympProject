using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AnimalVisitedLocation
    {
        public long Id { get; set; }

        public long AnimalId { get; set; }

        public long PointId { get; set; }

        public DateTime DateTimeOfVisitLocationPoint { get; set; }


        public Animal Animal { get; set; }
    }
}
