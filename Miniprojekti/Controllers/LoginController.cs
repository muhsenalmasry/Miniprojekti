using Microsoft.AspNetCore.Mvc;
using Miniprojekti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Miniprojekti.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string Nickname, string Password)
        {
            if(!string.IsNullOrEmpty(Nickname) || !string.IsNullOrEmpty(Password))
            {
                Academy21ChatDBContext db = new();
                var person = db.People.Where(p => p.NickName == Nickname && p.Password == Password).FirstOrDefault();
                if (person == null)
                {
                    return View();
                }
                HttpContext.Session.SetInt32("personId", person.PersonId);
                return RedirectToAction("Index", "Messages");
            }
            return View();
            
        }

        
    }
}
