using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto
{
    public class AttendanceDto
    {
        public int Id { get; set; }

        // Foreign Key
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan ExitTime { get; set; }
        public string Status { get; set; } // e.g., Present, Absent, Leave
    }
}
