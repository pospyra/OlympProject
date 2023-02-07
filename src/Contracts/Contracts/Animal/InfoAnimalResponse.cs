using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Animal
{
    public class InfoAnimalResponse
    {
        public long Id { get; set; }

        public long[] AnimalTypesId { get; set; }

        public ICollection<AnimalType> AnimalTypes { get; set; }

        public float Weihgt { get; set; }

        public float Length { get; set; }

        public float Height { get; set; }

        public string Gender { get; set; }

        public string LifeStatus { get; set; }

        public DateTime ChippingDateTime { get; set; }

        public int ChipperId { get; set; }

        public long ChippingLocationId { get; set; }

        public long[] VisitedLocations { get; set; }

        public DateTime DeathDateTime { get; set; }



    }
}
