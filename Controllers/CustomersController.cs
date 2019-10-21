using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();	
		}
		// GET: Customers
		public ActionResult Customers()
		{
			var customers = GetCustomers();
			//var customers = _context.Customers.ToList();

			if (customers == null)
				return HttpNotFound();

			return View(customers);
		}

		public IEnumerable<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				 new Customer {Id=1, Name = "John Smith" },
				 new Customer {Id=2, Name = "Mary Williams" }
			};
		}

		public ActionResult Details(int id)
		{
			//works with IEnumerable in the View
			//var customerInfo = GetCustomers().Where(p => p.Id == id);
			var customerInfo = GetCustomers().SingleOrDefault(p => p.Id == id);
			//var customerInfo = _context.Customers.SingleOrDefault(c => c.Id == id);
			/*foreach (Customer oneCustomer in GetCustomers().Where(p => p.Id == id))
			{
				customerDetails = oneCustomer.Name;
			}*/

			return View(customerInfo);
		}
	}
}