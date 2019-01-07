using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;

namespace RentACloth.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<RentAClothUser> userRepository;
        private readonly UserManager<RentAClothUser> userManager;

        //to get current user
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IRepository<RentAClothUser> userRepository, UserManager<RentAClothUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public RentAClothUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }

        public string GetCurrentUserUsername()
        {
            return this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
