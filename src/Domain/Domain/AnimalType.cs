using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AnimalType
    {
        /// <summary>
        /// Идентификатор типа животного
        /// </summary>
        public long Id { get; set; }

        public long AnimalId { get; set; }

        public long TypeNameId { get; set; }

        public TypeName TypeName { get; set; }

        public Animal Animal { get; set; }
    }
}
