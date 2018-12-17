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
    public class WatchesService:IWatchesService
    {
        private readonly IRepository<Watch> watchesRepository;

        public WatchesService(IRepository<Watch> watchesRepository)
        {
            this.watchesRepository = watchesRepository;
        }
        public IEnumerable<IndexProductViewModel> AllWatches()
        {
            return this.watchesRepository.All().To<IndexProductViewModel>();
        }
    }
}
