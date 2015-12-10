using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goodreads.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string UserName {get; set;}

        public string Picture { get; set; }

        [Required]
        public string Email { get; set; }

        public string Location { get; set; }

        [DisplayName("Bookshelves")]
        public virtual ICollection<BookList> UserBookLists { get; set; }

    }
}