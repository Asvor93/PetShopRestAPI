﻿using System;
using System.Collections.Generic;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PetType { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime SoldDate { get; set; }

        public List<PetColor> PetColors { get; set; }

        public Owner PreviousOwner { get; set; }

        public double Price { get; set; }
    }
}