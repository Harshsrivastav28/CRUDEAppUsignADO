using CRUDEAppUsignADO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDEAppUsignADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDataAccessLayer dal;

        public HomeController()
        {
            dal = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employees> emps = dal.getAllEmployees();

            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees emp)
        {
            try
            {
                dal.AddEmployees(emp);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
            
        }
        

        public IActionResult AboutSystem()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Employees emp = dal.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Employees emp)
        {
            try
            {
                dal.UpdateEmployees(emp);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }

        }

        public IActionResult details(int id)
        {
            Employees emp = dal.GetEmployeeById(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employees emp = dal.GetEmployeeById(id);
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employees emp )

        {
            try
            {
                dal.DeleteEmployee(emp.Id);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ??
                           HttpContext.TraceIdentifier
            });
        }
    }
}