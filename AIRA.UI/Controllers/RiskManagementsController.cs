﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AIRA.UI.Controllers
{
    public class RiskManagementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}