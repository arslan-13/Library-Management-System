﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ReturnController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}