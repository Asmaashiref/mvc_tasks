using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using task2.Models;

namespace task2.Controllers
{
    public class ProjectController : Controller
    {
        private CompanyContext _companyContext;
        public ProjectController()
        {
            _companyContext = new CompanyContext();
        }

        public IActionResult Getall()
        {
            List<project> projects = _companyContext.Projects.Include(p => p.Department).ToList();
            return View(projects);
        }
        public IActionResult Details(int id)
        {
            project project = _companyContext.Projects.Include(p => p.Department).SingleOrDefault(s => s.Id == id);
            return View(project);
        }
        public IActionResult Adddata()
        {
            List<department> departments = _companyContext.Departments.ToList();

            ViewData["departments"] = departments;
            return View();
        }
        public IActionResult GetFormData(string name, string location, string city, int deptId)
        {
            project project = new()
            {
                pname = name,
                plocation = location,
                city = city,
                dnum = deptId
            };

            _companyContext.Projects.Add(project);
            _companyContext.SaveChanges();

            return RedirectToAction("Getall");
        }
        public IActionResult Updatedata(int id)
        {
            project project = _companyContext.Projects.SingleOrDefault(s => s.Id == id);
            List<department> departments = _companyContext.Departments.ToList();

            ViewData["departments"] = departments;
            return View(project);
        }
        public IActionResult Update(int id, string name, string location, string city, int deptId)
        {

            project? project = _companyContext.Projects.SingleOrDefault(s => s.Id == id);
            project.pname = name;
            project.plocation = location;
            project.city = city;
            project.dnum = deptId;

            _companyContext.SaveChanges();

            return RedirectToAction("Getall");
        }
        public IActionResult delete(int id)
        {
            project project = _companyContext.Projects.SingleOrDefault(s => s.Id == id);
            _companyContext.Projects.Remove(project);
            _companyContext.SaveChanges();
            return RedirectToAction("Getall");
        }
    }
}