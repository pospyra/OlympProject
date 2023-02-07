using AppServices.IRepository;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.LocationPoint
{
    public class LocationPointService : ILocationPointService
    {
        public readonly ILocationPointRepository _locationPointRepository;
        public LocationPointService(ILocationPointRepository locationPointReposirory) 
        {
            _locationPointRepository= locationPointReposirory;
        }

        public async  Task<InfoLocationPointResponse> GetLocationPointById(long id)
        {
            var locationPoint = await _locationPointRepository.GetLocationyPointById(id);
            InfoLocationPointResponse pointRes = null;
            if (locationPoint == null)
                return pointRes;

            return pointRes = new InfoLocationPointResponse()
            {
                Id = locationPoint.Id,
                Longitude = locationPoint.Longitude,
                Latitude = locationPoint.Latitude,
            };
        }
    }
}
