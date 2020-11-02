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
                dbContext.SaveChanges();

            }

            return View();
        }
    }
}
