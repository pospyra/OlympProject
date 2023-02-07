using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class VisitedLocationResponse
    {
        public long Id { get; set; }

        public long PointId { get; set; }

        public DateTime DateTimeOfVisitLocationPoint { get; set; }

    }
}
