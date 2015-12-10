using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goodreads.Models
{
    public class Book
    {
        public int ID { get; set; }
        [DisplayName("Given tags")]
        public virtual ICollection<Tag> GivenTags { get; set; }
        public virtual BookList BookList{ get; set; }        

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public double Rate { get; set; }
 
    }
}