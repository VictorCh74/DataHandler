using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataHandler.Models;

namespace DataHandler.Controllers
{
    public class HomeController : Controller
    {
        static List<Person> Staff = new List<Person>() {
            new Person() {Id=1 , Name="Иванов" , SecondName ="Иван" , FatherName = "Иванович" , Position = "Директор" , Salary = 150000 , WorkExperience = 30 , EmpDate = new DateTime(2010, 7, 20), CssClass="non-selected-div" },
            new Person() {Id=2 , Name="Иванов" , SecondName ="Петр" , FatherName = "Иванович" , Position = "Главбух" , Salary = 100000 , WorkExperience = 30 , EmpDate = new DateTime(2010, 7, 20), CssClass="non-selected-div"},
            new Person() {Id=3 , Name="Петров" , SecondName ="Петр" , FatherName = "Петрович" , Position = "Бригадир" , Salary = 50000 , WorkExperience = 15 , EmpDate = new DateTime(2015, 12, 6), CssClass="non-selected-div" },
            new Person() {Id=4 , Name="Николаев" , SecondName ="Николай" , FatherName = "Николавич" , Position = "Токарь" , Salary = 150000 , WorkExperience = 25 , EmpDate = new DateTime(2010, 7, 20), CssClass="non-selected-div"},
            new Person() {Id=5 , Name="Сергеев" , SecondName ="Сергей" , FatherName = "Сергеевич" , Position = "Стропальщик" , Salary = 15000 , WorkExperience = 10 , EmpDate = new DateTime(2020, 5, 12), CssClass="non-selected-div"},
        };



        public IActionResult Index(int currentItem=1)
        {
            Staff.ForEach(p => p.CssClass = "non-selected-div");
            Staff[currentItem - 1].CssClass = "selected-div";
            ViewBag.Staff = Staff;
            ViewBag.CurrentItem = currentItem;
            return View();
        }

        [HttpGet]
        public IActionResult ItemDetails(int Id) {
            return PartialView(Staff.Where(p => p.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult SaveChanges(NewPersonData data) {
            var person = Staff.Where(p => p.Id == data.Id).FirstOrDefault();
            var newPerson = new Person() {
                Id = person.Id,
                Name = person.Name,
                SecondName = person.SecondName,
                FatherName = person.FatherName,
                Position = person.Position,
                WorkExperience = data.WorkExperience,
                EmpDate = data.EmpDate,
                Salary = data.Salary
            };
            Staff.Remove(person);
            Staff.Add(newPerson);
            Staff = Staff.OrderBy(p => p.Id).ToList();

            return RedirectToAction("Index", "Home" , data.Id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
