using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class AddBook
    {
        [Key]
        public int Id { get; set; }

        public int BookNo { get; set; }

        public string BookName { get; set; }

        public string BookAuthor { get; set; }
    }
}
