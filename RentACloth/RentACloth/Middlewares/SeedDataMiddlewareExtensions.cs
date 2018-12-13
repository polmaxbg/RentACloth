﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace RentACloth.Middlewares
{
    public static class SeedDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedDataMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
