using Assignment5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext context = new MyDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(context.Accounts);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateAccount(Account a)
        {
            //if (a.AccountNumber < 0)
            //{
            //    ModelState.AddModelError("AccountNumber", "Account  number cannot be negative");
            //}
            //if (string.IsNullOrEmpty(a.Name))
            //{
            //    ModelState.AddModelError("Name", "Account holder's  name is required");
            //}
            //if ((a.CurrentBalance >= 1 && a.CurrentBalance < 500) ||
            //            a.CurrentBalance < 0)
            //{
            //    ModelState.AddModelError("CurrentBalance", "Minimum balance must be atleast 500");
            //}

            if (ModelState.IsValid)
            {
                context.Accounts.Add(a);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");

        }

        public ActionResult Edit(int? accno)
        {
            var account_to_edit = (from a in context.Accounts
                                   where a.AccountNumber == accno
                                   select a).SingleOrDefault();
            return View(account_to_edit);
        }

        public ActionResult EditAccount(Account a)
        {
            context.Entry<Account>(a).State =EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? accno)
        {
            var account_to_delete = (from a in context.Accounts
                                     where a.AccountNumber == accno
                                     select a).SingleOrDefault();
            context.Entry<Account>(account_to_delete).State =EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}