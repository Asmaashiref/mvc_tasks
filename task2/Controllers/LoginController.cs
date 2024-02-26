using Microsoft.AspNetCore.Mvc;
using task2.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace task2.Controllers
{
    public class LoginController : Controller
    {
       private CompanyContext _companyContext=new CompanyContext();
        public IActionResult login()
        {
            return View();
        }
        public IActionResult logpage(string Fname, string password)
        {

            employee employee = _companyContext.Employees.SingleOrDefault(e => e.fname == Fname && e.password == password);
            if (employee != null)
            {
                HttpContext.Session.SetString("Fname", employee.fname);
                HttpContext.Session.SetString("password", employee.password);

                return RedirectToAction("GetAll", "employee");
                
            }
            return View("login");
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
