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
        public IActionResult Index(string Nickname, string Password)
        {
            if(!string.IsNullOrEmpty(Nickname) || !string.IsNullOrEmpty(Password))
            {
                Academy21ChatDBContext db = new();
                var henkilö = db.People.Where(p => p.NickName == Nickname && p.Password == Password).FirstOrDefault();
                if (henkilö == null)
                {
                    return View();
                }
                return RedirectToAction("Index", "Messages");
            }
            return View();
            
        }

        
    }
}
