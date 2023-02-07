using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.LocationPoint
{
    public interface ILocationPointService
    {
        public Task<InfoLocationPointResponse> GetLocationPointById(long id);
    }
}
