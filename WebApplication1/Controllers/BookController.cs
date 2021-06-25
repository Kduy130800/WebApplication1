using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private List<Book> listBooks;
        public BookController()
        {
            listBooks = new List<Book>();
            listBooks.Add(new Book()
            {
                Id = 1,
                Title = "Sach 1",
                Author = "Nguyen Nhat Anh",
                Price = 40000,
                ImageCover = "Content/images/sach 1.jfif"
            }) ;
            listBooks.Add(new Book()
            {
                Id = 2,
                Title = "Sach 2",
                Author = "Nguyen Kim Dong",
                Price = 30000,
                ImageCover = "Content/images/sach 2.jfif"
            });
            listBooks.Add(new Book()
            {
                Id = 3,
                Title = "Sach 3",
                Author = "Alexander Duy ",
                Price = 80000,
                ImageCover = "Content/images/sach 3.jfif"
            });
        }

       
        public ActionResult ListBook()
        {
            ViewBag.TitlePageName = "Book view page";
            return View(listBooks);

        }
        //nút SAVE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.Id == book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.ImageCover = book.ImageCover;
                    editBook.Price = book.Price;
                    editBook.Publicyear = book.Publicyear;
                    return View("ListBook", listBooks);
                } catch (Exception ex)
                {
                    return HttpNotFound();
                }

             }
            else
            {
                ModelState.AddModelError("", "Input Model Not Valid!");
                return View(book);
            }
        }
        public ActionResult Edit(int id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }
    }
}