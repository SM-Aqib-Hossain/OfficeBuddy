﻿namespace UIPortal.Components.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int? Balance { get; set; } = 0;

        // Foreign Key
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public DateTime JoiningDate { get; set; }
    }

}
