using Goodreads.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Goodreads.DAL
{
    public class GoodreadsContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookList> BookLists { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}