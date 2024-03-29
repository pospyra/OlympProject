﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Animal
    {
        public Animal() 
        {
            LifeStatus = "ALIVE";
        }

        public long Id { get; set; }

        public float Weihgt { get; set; }

        public float Length { get; set; }

        public float Height { get; set; }

        public string Gender { get; set; }

        public string LifeStatus { get; set; }

        public DateTime ChippingDateTime { get; set;}

        public int ChipperId { get; set; }

        public long ChippingLocationId { get; set;}

        public DateTime DeathDateTime { get; set; }

        public Account Account { get; set; }

        public ICollection<AnimalType>? AnimalType { get; set; }

        public ICollection<AnimalVisitedLocation>? VisitedLocation { get; set; }
    }
}
