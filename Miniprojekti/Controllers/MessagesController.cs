using Microsoft.AspNetCore.Mvc;
using Miniprojekti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Miniprojekti.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateMessage()
        {
            ViewBag.personId = HttpContext.Session.GetInt32("personId");
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage([FromForm] Message message)
        {
            if (message != null)
            {
                Academy21ChatDBContext chatdb = new();
                chatdb.Messages.Add(message);
                chatdb.SaveChanges();
                return RedirectToAction("ReadMessages");
            }
            else
            {
                return View();
            }
        }
        public IActionResult ReadMessages()
        {
            Academy21ChatDBContext chatdb = new();
            return View(chatdb.Messages.ToList());
        }
    }
}
