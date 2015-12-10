using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goodreads.Models
{
    public class BookList
    {
        [DisplayName("Books")]
        public virtual ICollection<Book> BookName { get; set; }

        public virtual User User { get; set; }
    
        public int ID { get; set; }

        [Required]
        public string BookListName { get; set; } //read, currently reading, to read (police)
        

        
    }


}