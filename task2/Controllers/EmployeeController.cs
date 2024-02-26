using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using task2.Models;

namespace task2.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyContext _companyContext;

        public EmployeeController()
        {
            _companyContext = new CompanyContext();
        }
        public IActionResult GetAll()
        {
            List<employee>employees =_companyContext.Employees.Include(i=>i.Department).ToList();

           

            return View(employees);
            

        }
        public IActionResult Details(int id)
        {
            employee employee = _companyContext.Employees.Include(i => i.Department).Include(e => e.Works_Fors).ThenInclude(p=>p.Project).SingleOrDefault(s => s.Id == id);
           
            return View(employee);
        }
        public IActionResult edit(int id, int projectid ,int houres) {
            var employee=_companyContext.Employees.Include(w=>w.Works_Fors).ThenInclude(p=>p.Project).SingleOrDefault(e=>e.Id == id);

          

           
            //return View(employee);

            
            if (employee == null)
            {
                return NotFound();
            } 

            var worksFor = employee.Works_Fors.SingleOrDefault(); 
            if (worksFor != null)
            {
                worksFor.pnum = projectid;
                worksFor.houres = houres;
                _companyContext.SaveChanges();
                return RedirectToAction("Index"); // Redirect to desired action
            }

            return BadRequest("Works_For entry not found for employee.");
        }
    }


}

