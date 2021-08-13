using Microsoft.AspNetCore.Mvc;
using Miniprojekti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage([FromForm] Message message)
        {
                Academy21ChatDBContext chatdb = new();
                chatdb.Messages.Add(message);
                return View();
        }
        public IActionResult ReadMessages()
        {
            Academy21ChatDBContext chatdb = new();
            return View(chatdb.Messages.ToList());
        }
    }
}
