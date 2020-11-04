using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BookAppDbContext: DbContext

    {

        public DbSet<Book> Books{ get; set; }

        public DbSet<AddBook> AddBooks { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=LibraryManagement;Trusted_Connection=True;");
        }
    }
}
