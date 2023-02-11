using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface ILocationPointRepository
    {
        public IQueryable<LocationPoint> GetAll();
        public Task<LocationPoint> GetLocationyPointById(long id);

        public Task AddPoint(LocationPoint locationPoint);
        public Task EditPoint(LocationPoint locationPoint);
        public Task DeletePoint(LocationPoint locationPoint);
    }
}
