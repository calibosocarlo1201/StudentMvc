using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMvc.Data;
using StudentMvc.Models;
using StudentMvc.Models.Entities;
using System.Diagnostics;

namespace StudentMvc.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student _data)
        {

            if (ModelState.IsValid)
            {

                //var student = new Student
                //{
                //    Name = _data.Name,
                //    Email = _data.Email,
                //    Phone = _data.Phone,
                //    Subscribe = _data.Subscribe,
                //};

                await _dbContext.Students.AddAsync(_data);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(_data);
        }

        [HttpGet]
        public async Task<IActionResult> StudentsList()
        {
            var students = await _dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student _data)
        {
            var student = await _dbContext.Students.FindAsync(_data.Id);
            
            if (student is not null)
            {
                student.Name = _data.Name;
                student.Email = _data.Email;
                student.Phone = _data.Phone;
                student.Subscribe = _data.Subscribe;

                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("StudentsList", "Students");
        }

        [HttpPost]    
        public async Task<IActionResult> DeleteStudent(Guid Id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == Id);
            Debug.WriteLine("Student: " + student);
            if (student is not null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("StudentsList", "Students");
        }
    }
}
