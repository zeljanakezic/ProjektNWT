using Goodreads.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Goodreads.DAL
{
    public class GoodreadsInitializer : DropCreateDatabaseAlways<GoodreadsContext>
    {
        protected override void Seed(GoodreadsContext context)
        {
            var users = new List<User>()
            {
                new User() { UserName = "Jana",Email="jana@gmail.com"},
                new User() { UserName = "Mate",Email="mate@gmail.com"},
                new User() { UserName = "Ivan",Email="ivan@gmail.com"},
                new User() { UserName = "Marijana",Email="marijanagmail.com"}
            };
            users.ForEach(user => context.Users.Add(user));

            var tags = new List<Tag>()
            {
                new Tag() { Name = "love" },
                new Tag() { Name = "life" },
                new Tag() { Name = "adventure" },
                new Tag() { Name = "philosophy" },

            };
            tags.ForEach(tag => context.Tags.Add(tag));

            var books = new List<Book>()
            {
                new Book() { GivenTags = new List<Tag>() { tags[0], tags[2]}, Author = "Mato Lovrak", Title = "Vlak u snijegu", Description = "...", Rate=3.7 },
                new Book() { GivenTags = new List<Tag>() { tags[1] }, Author = "Ivo Andric", Title = "Na Drini cuprija", Description = "...", Rate = 4.7 },
                new Book() { GivenTags = new List<Tag>() { tags[2] }, Author = "Lav Nikolajevic Tolstoj", Title = "Ana Karenjina", Description = "...", Rate = 4.5 },       
                new Book() { GivenTags = new List<Tag>() { tags[3],tags[1] }, Author = "Ivo Andric", Title = "Na Drini cuprija", Description = "Jedan od najpoznatijih romana bosanskohercegovačkog knjizevnika Ive Andrica.", Rate=2.3 },
                new Book() { GivenTags = new List<Tag>() { tags[1]}, Author = "Fjodor Mihajlovic Dostojevski", Title = "Zlocin i kazna", Description = "Smatra se jednim od najvecih djela ruske knjizevnosti.", Rate=5 },
                new Book() { GivenTags = new List<Tag>() { tags[2],tags[3] }, Author = "Lav Nikolajevic Tolstoj", Title = "Ana Karenjina", Description = "Roman sa suvremenom tematikom u kojoj je sredisnja tema preljub glavnog lika Ane.", Rate=3.5 }, 
                
                
           };

            books.ForEach(book => context.Books.Add(book));

            var booklists = new List<BookList>()
            {
                new BookList() { BookName = new List<Book>() { books[0],books[2] }, User = users[0], BookListName = "Read" },
                new BookList() { BookName = new List<Book>() { books[1],books[4],books[3] }, User = users[0], BookListName = "To-read" },
                new BookList() { BookName = new List<Book>() { books[5] }, User = users[0], BookListName = "Currently-reading"},
            };

            booklists.ForEach(list => context.BookLists.Add(list));

            users[0].UserBookLists =  booklists;

            try {
                context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                var b = e;
            }
        }
    }
}