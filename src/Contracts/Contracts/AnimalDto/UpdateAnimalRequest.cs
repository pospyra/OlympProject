using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AnimalDto
{
    public class UpdateAnimalRequest
    {
        public float Weihgt { get; set; }

        public float Length { get; set; }

        public float Height { get; set; }

        public string Gender { get; set; }

        public string LifeStatus { get; set; }

        public int ChipperId { get; set; }

        public long ChippingLocationId { get; set; }

    }
}
