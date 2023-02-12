using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AnimalDto
{
    public class AddAnimalRequest
    {
        public long[] AnimalTypes { get; set; }

        public float Weihgt { get; set; }

        public float Length { get; set; }

        public float Height { get; set; }

        public string Gender { get; set; }

        public int ChipperId { get; set; }

        public long ChippingLocationId { get; set; }

    }
}
