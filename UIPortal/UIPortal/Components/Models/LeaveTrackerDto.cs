using System.ComponentModel.DataAnnotations;

namespace UIPortal.Components.Models
{
    public class LeaveTrackerDto
    {
        public int Id { get; set; } // Primary Key

        //// Foreign Key linking to the Employee
        public int EmployeeId { get; set; }

        //public DateTime LeaveDate { get; set; } // Date of leave start
        //public string LeaveType { get; set; } // "Sick Leave," "Casual Leave," 
        //public string? Reason { get; set; } // Optional reason for the leave
        //public string? Status { get; set; } // E.g., "Approved," "Pending," "Rejected"

        //public DateTime RequestDate { get; set; }
        //public DateTime? ApprovalDate { get; set; } // Date when leave was approved/rejected
        //public int DaysRequested { get; set; } //number ef days granted


        [Required(ErrorMessage = "Leave Type is required.")]
        public string? LeaveType { get; set; }

        [Required(ErrorMessage = "Leave Date is required.")]
        public DateTime? LeaveDate { get; set; }

        [Range(1, 3, ErrorMessage = "Days requested must be between 1 and 3.")]
        public int DaysRequested { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        public string? Reason { get; set; }

        public string? Status { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}
