﻿using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Services.Models.Home;

namespace RentACloth.Services.Contracts
{
    public interface IWatchesService
    {
        IEnumerable<IndexProductViewModel> AllWatches();

    }
}