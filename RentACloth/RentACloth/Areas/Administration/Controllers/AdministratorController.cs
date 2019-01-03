using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Controllers;

namespace RentACloth.Areas.Administration.Controllers
{
    [Area("Аdministration")]
    [Authorize(Roles = "Admin")]
    public class AdministratorController:Controller
    {
    }
}
