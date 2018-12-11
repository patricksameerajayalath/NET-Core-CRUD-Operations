using Microsoft.AspNetCore.Mvc;
using NETCoreCRUDOperations.DataAccessLayer;
using NETCoreCRUDOperations.Models;

namespace NETCoreCRUDOperations.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer customerDAL = new CustomerDataAccessLayer();

        public IActionResult Index()
        {
            var customerList = customerDAL.GetAllCustomers();

            return View(customerList);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = customerDAL.GetCustomerData(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                customerDAL.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = customerDAL.GetCustomerData(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = customerDAL.GetCustomerData(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            customerDAL.DeleteCustomer(id.Value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerDAL.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }
    }
}