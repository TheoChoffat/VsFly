﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebApi.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
