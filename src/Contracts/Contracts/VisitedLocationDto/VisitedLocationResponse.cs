using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.VisitedLocationDto
{
    public class VisitedLocationResponse
    {
        public long Id { get; set; }

        public DateTime DateTimeOfVisitLocationPoint { get; set; }

        public long PointId { get; set; }

    }
}
