﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        WebShopContext db = new WebShopContext();
        
        public ActionResult Index()
        {
            //// получаем из бд все объекты Book
            //IEnumerable<Book> books = db.Books;
            //// передаем все полученный объекты в динамическое свойство Books в ViewBag
            //ViewBag.Books = books;
            //// возвращаем представление

            IEnumerable<Vegetable> vegetables = db.Vegetables;
            ViewBag.Vegetables = vegetables;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо,"  + ", за покупку!";
        }
    }
}
