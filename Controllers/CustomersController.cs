using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

		public ActionResult New()
		{
			// var membershipTypes = _context.MembershipTypes.ToList();
			//var membershipTypes
			var viewModel = new CustomerFormViewModel
			{
				// MembershipTypes = membershipTypes;
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Customer customer)
		{
			// _context.Customer.Add(customer);
			// _context.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id = id);

			if (customer==null)
			{
				return HttpNotFound();
			}

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("New", viewModel);
		}

		// GET: Customers
		public ActionResult Index()
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