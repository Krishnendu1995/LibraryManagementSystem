﻿using System;
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

        public IActionResult Indexx()
        {
            return View();
        }
        public IActionResult Login()

        {

            return View();
        }

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
    }

}
