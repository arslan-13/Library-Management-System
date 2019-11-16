using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }


        public int CustID { get; set; }
        public Customer Customer { get; set; }
    }
}
