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

        /// <summary>
        /// Тип животного
        /// </summary>
        public string Type { get; set; }

        public long? AnimalId { get; set; }

        public Animal? Animal { get; set; }
    }
}
