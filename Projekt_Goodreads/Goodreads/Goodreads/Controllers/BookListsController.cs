using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Goodreads.DAL;
using Goodreads.Models;

namespace Goodreads.Controllers
{
    public class BookListsController : Controller
    {
        private GoodreadsContext db = new GoodreadsContext();

        // GET: BookLists
        public ActionResult Index()
        {
            return View(db.BookLists.ToList());
        }

        // GET: BookLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookList bookList = db.BookLists.Find(id);
            if (bookList == null)
            {
                return HttpNotFound();
            }
            return View(bookList);
        }

        // GET: BookLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookListName")] BookList bookList)
        {
            if (ModelState.IsValid)
            {
                db.BookLists.Add(bookList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookList);
        }

        // GET: BookLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookList bookList = db.BookLists.Find(id);
            if (bookList == null)
            {
                return HttpNotFound();
            }
            return View(bookList);
        }

        // POST: BookLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookListName")] BookList bookList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookList);
        }

        // GET: BookLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookList bookList = db.BookLists.Find(id);
            if (bookList == null)
            {
                return HttpNotFound();
            }
            return View(bookList);
        }

        // POST: BookLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookList bookList = db.BookLists.Find(id);
            db.BookLists.Remove(bookList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
