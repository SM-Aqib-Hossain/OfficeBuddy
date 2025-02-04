using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int? Balance { get; set; }

        // Foreign Key
        public int? DepartmentId { get; set; }
        public string?  DepartmentName { get; set; }

        public DateTime JoiningDate { get; set; }
    }
}
