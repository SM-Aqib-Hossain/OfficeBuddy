using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        // Foreign Key
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan ExitTime { get; set; }
        public string Status { get; set; } // e.g., Present, Absent, Leave
    }
}
