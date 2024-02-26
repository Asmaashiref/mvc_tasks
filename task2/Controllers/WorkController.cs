using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using task2.Models;
using task2.ViewModels;

namespace task2.Controllers
{
    public class WorkController : Controller
    {
        CompanyContext companyContext;
        public WorkController()
        {

            companyContext = new CompanyContext();

        }
        public IActionResult Getall()
        {
            List<works_for> works_Fors = companyContext.works_Fors.Include(w => w.Project).Include(w => w.Employee).ToList();
            return View(works_Fors);
        }
        public IActionResult Edit(int id)
        {
            employee emp = companyContext.Employees.Where(p => p.Id == id).SingleOrDefault();
            List<project> project = companyContext.works_Fors.Include(w => w.Project).Where(w => w.essn == id).Select(p => p.Project).ToList();

            ViewBag.project = project;
          
            ViewBag.employee = emp;
            return View();
        }
        public IActionResult EditDB(works_for works)
        {
            companyContext.works_Fors.Update(works);
            companyContext.SaveChanges();
            return RedirectToAction("Getall");
        }

        public IActionResult editscript(int id, int ssn)
        {
            works_for hours = companyContext.works_Fors.Where(w => w.pnum == id && w.essn == ssn).FirstOrDefault();

            return PartialView("_editpartial", hours);

        }
    }
}