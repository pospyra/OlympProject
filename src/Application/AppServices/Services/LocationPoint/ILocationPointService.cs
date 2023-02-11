using Contracts.LocationPoint;
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

        public Task<InfoLocationPointResponse> AddLocation( AddOrUpdatePointRequest request);

        public Task<InfoLocationPointResponse> EditLocation(long id, AddOrUpdatePointRequest request);

        public Task DeleteLocation(long id);
    }
}
