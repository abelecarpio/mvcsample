using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using MvcSample.Data;
using MvcSample.Entities;

namespace MvcFrontEnd.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            ViewBag.Title = "Account";
            var model = new List<Customer>();
            try
            {
                model = GetCustomers();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Customer());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid) return RedirectToAction("Index", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(customer);
        }


        private List<Customer> GetCustomers()
        {
            CustomerManager manager = null;
            try
            {
                manager = new CustomerManager();
                var result = manager.GetCustomerFromDatabase();
                if (!result.IsSuccess) throw result.TransactionException;
                return result.OperationResult == null ? new List<Customer>() : result.OperationResult.ToList();
            }
            finally
            {
                if (manager != null) manager.Dispose();
            }
            return new List<Customer>();
        }



    }
}
