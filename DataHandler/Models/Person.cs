using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataHandler.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string FatherName { get; set; }
        public string Position { get; set; }
        public int WorkExperience { get; set; }
        public DateTime EmpDate { get; set; }
        public int Salary { get; set; }
        public string CssClass { get; set; }
    }
}
