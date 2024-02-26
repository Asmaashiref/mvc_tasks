using Microsoft.AspNetCore.Mvc;
using task2.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using task2.Models;
using Microsoft.EntityFrameworkCore;


namespace task2.Controllers
{
    public class ValidempController : Controller
    {
        CompanyContext companyContext=new CompanyContext();
        
        public IActionResult Index()
        {
            List<employee> employees = companyContext.Employees.Include(d=>d.Department).ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add() {

            EmployeeVM employeeVM = new EmployeeVM()
            {
                departments = new SelectList(companyContext.Departments, nameof(department.Id), nameof(department.Name))
            };
            return View(employeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeeVM emp) {
         if (ModelState.IsValid)
         {
                employee employee = new employee()
                {
                    fname = emp.fname,
                    lname = emp.lname,
                    address= emp.address,
                    password = emp.password,
                    dno = emp.dno,
                    bdate = emp.bdate,
                    salary = emp.salary,
                    Sex=emp.Sex
                };
                companyContext.Employees.Add(employee);
                companyContext.SaveChanges();
                return RedirectToAction(nameof(Index));
                
         }
            List<department>departments = companyContext.Departments.ToList(); 

            emp.departments=new SelectList(departments,nameof(department.Id),nameof(department.Name));

            return View(emp);
        }
    }
}
