using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ProductClientController : Controller
    {
        // GET: ProductClient
        public ActionResult Index()
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44326/Api/Product");
                //HTTP GET
                var responseTask = client.GetAsync("Product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Product>>();
                    readTask.Wait();
                    products = readTask.Result;
                }
                else //web api sent error response 
                {
                    products = Enumerable.Empty<Product>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(products);
            //model - list of product objects
            
        }

        // GET: ProductClient/Details/5
        public ActionResult Details(int id)
        {
            Product product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44326/Api/Product");
                //HTTP GET
                var responseTask = client.GetAsync("Product?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Product>();
                    readTask.Wait();
                    product = readTask.Result;
                }
            }
            return View(product);
            //return View();
        }

        // GET: ProductClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductClient/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductClient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductClient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductClient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductClient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
