using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register(Book Book)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Book Book)
        {
            ShareMail mail = new ShareMail();
            mail.SendEmail(Book.Email);
            return View();
        }

        
        public IActionResult BookDetails()
        {
            return View();
        }

        
        public IActionResult BookAvail()
        {
            return View();
        }

    }
}
