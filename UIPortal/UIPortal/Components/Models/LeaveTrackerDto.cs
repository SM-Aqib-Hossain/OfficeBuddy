namespace UIPortal.Components.Models
{
    public class LeaveTrackerDto
    {
        public int Id { get; set; } // Primary Key

        // Foreign Key linking to the Employee
        public int EmployeeId { get; set; }

        public DateTime LeaveDate { get; set; } // Date of leave start
        public string LeaveType { get; set; } // "Sick Leave," "Casual Leave," 
        public string? Reason { get; set; } // Optional reason for the leave
        public string? Status { get; set; } // E.g., "Approved," "Pending," "Rejected"

        public DateTime RequestDate { get; set; }
        public DateTime? ApprovalDate { get; set; } // Date when leave was approved/rejected
        public int DaysRequested { get; set; } //number ef days granted
    }
}
