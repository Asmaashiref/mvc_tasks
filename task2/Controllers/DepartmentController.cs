using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using task2.Models;

namespace task2.Controllers
{
    public class DepartmentController : Controller
    {
        private CompanyContext _companyContext;
        public DepartmentController()
        {
            _companyContext = new CompanyContext();
        }
        public IActionResult Getall()
        {
            List<department> departments = _companyContext.Departments.Include(p => p.managr).ToList();
            return View(departments);
        }
      
        public IActionResult AddDept() {
            List<employee> employees = _companyContext.Employees.ToList();
            List<employee> manage_dept =_companyContext.Departments.Include(m=> m.managr).Select(d=>d.managr).ToList();
            List<employee> manage_emp= employees.Except(manage_dept).ToList();
            ViewBag.managr = manage_emp;
            return View();
        
        }
        public IActionResult Add(department department)
        {

           
            _companyContext.Departments.Add(department);

            _companyContext.SaveChanges();
           
                

            return RedirectToAction("Getall", "department");

            
        }
        public IActionResult Editform (int Id) { 
          department department= _companyContext.Departments.SingleOrDefault(p=>p.Id==Id);
            List<employee> employees = _companyContext.Employees.ToList();
            List<employee> manage_dept = _companyContext.Departments.Include(m => m.managr).Select(d => d.managr).ToList();
            List<employee> manage_emp = employees.Except(manage_dept).ToList();
            //List<employee> avilablemangr =manage_dept.Union(manage_dept).ToList();
            ViewBag.managr = manage_emp;

            return View(department);
        
        }
        public IActionResult edit(department department) { 
          _companyContext.Departments.Update(department);
            _companyContext.SaveChanges();
            return RedirectToAction("Getall", "department");
        }
        public IActionResult delete(int Id) { 
          department department =_companyContext.Departments.SingleOrDefault(m => m.Id==Id);
            _companyContext.Remove(department);
            _companyContext.SaveChanges();
           
            return RedirectToAction("Getall");
        
        }
    }
}
