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
        [HttpPost]
        public IActionResult ForLogin(string email,string password)
        {

            BookAppDbContext dbContext = new BookAppDbContext();
            string Email = email;

            string Password = password;
            var userlist = dbContext.Books.ToList();
            var user = userlist.Where(X => X.Email == email && X.Password == password).FirstOrDefault();

            if (user != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

           
        }


        public IActionResult Register(Book Book)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Book Book)
        {
            BookAppDbContext dbContext = new BookAppDbContext();
            Book obj = new Book();
            obj.FirstName = Book.FirstName;
            obj.LastName = Book.LastName;
            obj.CourseName = Book.CourseName;
            obj.CourseYear = Book.CourseYear;
            obj.Phone = Book.Phone;
            obj.Address = Book.Address;
            obj.City = Book.City;
            obj.Email = Book.Email;

            ShareMail mail = new ShareMail();
           string pass= mail.SendEmail(Book.Email);
            obj.Password = pass;


            dbContext.Add(obj);
            dbContext.SaveChanges();

           
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

        public IActionResult SelectBook()
        {
            BookAppDbContext dbContext = new BookAppDbContext();
            var SelectedList = dbContext.AddBooks.ToList();
            return View(SelectedList);
        }

    }
}
