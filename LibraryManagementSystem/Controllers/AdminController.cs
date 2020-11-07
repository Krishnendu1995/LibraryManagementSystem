using System;
using System.Collections.Generic;
using System.IO;
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

       
        public IActionResult AdminHome(string email, string password)

        {
            BookAppDbContext dbContext = new BookAppDbContext();
            
            string Email = email;
            string Password = password;
            var loginlist = dbContext.AdminLogins.ToList();
            var user = loginlist.Where(X => X.Email == email && X.Password == password).FirstOrDefault();

            if (user != null)
            {

                return View();

            }
            else
            {
                
                return RedirectToAction("Invalid");
            }


            
        }
        
        //public IActionResult Forlogin(AdminLogin adminLogin)

        //{
        //    using (BookAppDbContext dbContext = new BookAppDbContext())
        //    {
        //        dbContext.AdminLogins.Add(adminLogin);
        //        dbContext.SaveChanges();

        //    }

        //    return View();
          
        //}



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
        [HttpPost]
        public async Task<IActionResult> ForAddBookAsync(AddBook addbook)
        {
            if (addbook.FileToUpload == null || addbook.FileToUpload.Length == 0)
                return Content("file not selected");
            //string path = (@"C:\Users\nithe\Source\Repos\KD-Company\KD Company\wwwroot\Car\");
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Image",
                       addbook.FileToUpload.FileName);
            Console.WriteLine(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await addbook.FileToUpload.CopyToAsync(stream);
            }
            using (BookAppDbContext dbContext = new BookAppDbContext())
            {
                addbook.FileName = addbook.FileToUpload.FileName;
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

        public IActionResult ViewFeedback()
        {
            BookAppDbContext dbContext = new BookAppDbContext();
            var feedbackList = dbContext.Feedbacks.ToList();

            return View(feedbackList);
        }
    }

}
