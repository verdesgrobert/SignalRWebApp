using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SignalRWebApp.Models;
using SignalRWebApp.SqlServerNotifier;

namespace SignalRWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private SignaRTestContext db = new SignaRTestContext();

        public async Task<ActionResult> Index()
        {
            ViewBag.neProduct = db.GetNotifierEntity<Product>(db.Products).ToJson();
            ViewBag.neCustomer = db.GetNotifierEntity<Customer>(db.Customers).ToJson();
            var prodx = await db.Products.ToListAsync();
            var customs = await db.Customers.ToListAsync();

            return View(new MyClass() { Products = await db.Products.ToListAsync(), Customers = await db.Customers.ToListAsync() });
        }

        public async Task<ActionResult> IndexPartialProduct(MyClass myClass)
        {
            var collection = db.Products;
            ViewBag.neProduct = db.GetNotifierEntity<Product>(db.Products).ToJson();
            return PartialView(await collection.ToListAsync());
        }
        public async Task<ActionResult> IndexPartialCustomer(MyClass myClass)
        {
            var collection = db.Customers;
            ViewBag.neCustomer = db.GetNotifierEntity<Customer>(db.Customers).ToJson();
            return PartialView(await collection.ToListAsync());
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
