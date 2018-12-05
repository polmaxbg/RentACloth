using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Services.Models.Categories
{
    public class CategoryIdAndNameViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
