using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TypeName
    {
        /// <summary>
        /// Идентификатор типа 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название типа
        /// </summary>
        public string Type { get; set; }

        public ICollection<AnimalType> AnimalType { get; set; }
    }
}
