using AustriaCardTest.Data;
using AustriaCardTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AustriaCardTest.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }


        public IActionResult CustomerInformations(int? id)
        {
            if (id == null)
                return View(new Customer());

            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            try
            {
                if (customer == null)
                    TempData["Error"] = "Inputs cannot be empty!";

                bool hasRequiredFields =
                    !string.IsNullOrEmpty(customer.Name) &&
                    !string.IsNullOrEmpty(customer.Email) &&
                    !string.IsNullOrEmpty(customer.Address);

                if (customer.Id == 0)
                {
                    if (hasRequiredFields)
                    {
                        _context.Customers.Add(customer);
                        TempData["Success"] = "Saved successfully!";
                    }
                    else
                        TempData["Error"] = "Inputs cannot be empty!";
                }
                else
                {
                    _context.Customers.Update(customer);
                    TempData["Success"] = "Saved successfully!";
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
