using Microsoft.AspNetCore.Mvc;
using Miniprojekti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miniprojekti.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(Person p)
        {
            if(p == null)
                return View();
            else
            {
                Academy21ChatDBContext db = new();
                var viestit = db.Messages.Select(m=>m);
                foreach (var v in viestit)
                {
                    db.Entry(v).Collection("FromPerson").Load();
                }
                return View(viestit);
            }
        }
    }
}
