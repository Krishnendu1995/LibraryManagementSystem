using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Indexx()
        //{
        //    return View();
        //}
        public IActionResult AdminHome(string email, string password)

        {
            BookAppDbContext dbContext = new BookAppDbContext();
            
            string Email = email;
            string Password = password;
            var loginlist = dbContext.AdminLogins.ToList();
            var user = loginlist.Where(X => X.Email == email && X.Password == password).FirstOrDefault();

            if (user != null)
            {

                //    return View();//
                return RedirectToAction("Invalid");
            }
            else
            {
                return View();
            }


            
        }
        //public IActionResult Login()

        //{

        //    return View();
        //}

        public IActionResult Forlogin(AdminLogin adminLogin)

        {
            using (BookAppDbContext dbContext = new BookAppDbContext())
            {
                dbContext.AdminLogins.Add(adminLogin);
                dbContext.SaveChanges();

            }

            return View();
          
        }



        public IActionResult UserDetails()
        {
            BookAppDbContext dbContext = new BookAppDbContext();
            var UserList = dbContext.Books.ToList();
            return View(UserList);
        }

        
        public IActionResult AddBook()
        {
            
                return View();
            

        }

        public IActionResult ForAddBook(AddBook addbook)
        {
            using (BookAppDbContext dbContext = new BookAppDbContext())
            {
                dbContext.AddBooks.Add(addbook);
                //dbContext.AddBooks.Add(addbook.SelectedStatus=="0").;
                /// dbContext.addbook.SelectedStatus == "0";
                dbContext.SaveChanges();

            }

            return View();
    
        }
        public IActionResult BookDetails()
        {

            BookAppDbContext dbContext = new BookAppDbContext();
            var BookList = dbContext.AddBooks.ToList();
            return View(BookList);
            
        }

        public IActionResult SelectedBooks()
        {

            BookAppDbContext dbContext = new BookAppDbContext();

            var SelectedList = dbContext.AddBooks.ToList().Where(x => x.SelectedStatus == "1");

            return View(SelectedList);

        }
    }

}
