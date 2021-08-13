using Microsoft.AspNetCore.Mvc;
using Miniprojekti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miniprojekti.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index(Person person)
        {
            
            return View();
        }
    }
}
