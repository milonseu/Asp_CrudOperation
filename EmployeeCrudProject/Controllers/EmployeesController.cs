using EmployeeCrudProject.Data;
using EmployeeCrudProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeesController(AppDbContext db) => _db = db;

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var list = await _db.Employees.AsNoTracking().ToListAsync();
            return View(list);
        }



        // POST: Employees/Create
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", _db.Employees.ToList());
        }

        // ---------------- Edit Employee Form ----------------
        public IActionResult Edit(int id)
        {
            var emp = _db.Employees.Find(id);
            if (emp == null)
                return NotFound();

            return View(emp); // We’ll create Edit.cshtml
        }

        // ---------------- Update Employee ----------------
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(emp).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // Optional: Delete
        public IActionResult Delete(int id)
        {
            var emp = _db.Employees.Find(id);
            if (emp != null)
            {
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult EmployeeSalary()
        {
            var data = from e in _db.Employees
                       join s in _db.Salary
                       on e.Id equals s.EmpId
                       select new EmployeeSalaryVM
                       {
                           EmployeeName = e.EmpName,
                           Salary = s.EmpSalary
                       };

            return View(data.ToList());
        }
    }
}
