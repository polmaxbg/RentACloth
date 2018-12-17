using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Common;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Home;

namespace RentACloth.Services
{
    public class AccessoriesService:IAccessoriesService
    {
        private readonly IRepository<Accessories> accessoriesSerice;

        public AccessoriesService(IRepository<Accessories> accessoriesSerice)
        {
            this.accessoriesSerice = accessoriesSerice;
        }
        public IEnumerable<IndexProductViewModel> AllAccessories()
        {
            return this.accessoriesSerice.All().To<IndexProductViewModel>();
        }
    }
}
