using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.LocationPoint
{
    public class AddOrUpdatePointRequest
    {
        /// <summary>
        /// Географическая широта в градусах
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Географическая долгота в градусах
        /// </summary>
        public double Longitude { get; set; }
    }
}
