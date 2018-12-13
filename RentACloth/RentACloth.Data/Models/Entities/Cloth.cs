﻿using RentACloth.Data.Models.Enums;

namespace RentACloth.Data.Models.Entities
{
    public class Cloth : Product
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public ClothType ClothType { get; set; }
    }
}