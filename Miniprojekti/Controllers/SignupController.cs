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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            Academy21ChatDBContext db = new();
            var person2 = db.People.Where(p => p.NickName == person.NickName).FirstOrDefault();
            if (person2 == null)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            ViewBag.ilmoitus = "There is another person with the same Nickname. Please choose other Nickname!";
            return View();
        }
    }
}
