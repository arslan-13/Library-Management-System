using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.ViewModel
{
    public class BookViewModel
    {
        public Book book { get; set; }

        public IEnumerable<Author> authors { get; set; }
    }
}
