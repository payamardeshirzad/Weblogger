﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Weblogger.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}