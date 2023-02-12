using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.VisitedLocationDto
{
    public class EditVisitedLocationRequest
    {
        public long Id { get; set; }

        public long PointId { get; set; }
    }
}
