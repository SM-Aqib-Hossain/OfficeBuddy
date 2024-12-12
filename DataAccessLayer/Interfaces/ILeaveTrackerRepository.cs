using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILeaveTrackerRepository
    {
        Task<LeaveTracker> AddLeave(LeaveTracker leaveTracker);
        Task<LeaveTracker> GetLeaveById(int id);
        Task<List<LeaveTracker>> GetAllLeaves();
        Task<LeaveTracker> UpdateLeave(int id, LeaveTracker leaveTracker);
        Task DeleteLeave(int id);

        // Additional Utility Methods

        Task<List<LeaveTracker>> GetLeavesByEmployeeId(int employeeId);
        Task<List<LeaveTracker>> GetLeavesByDateRange(DateTime startDate, DateTime endDate);
        Task<List<LeaveTracker>> GetPendingLeaves();
        Task<List<LeaveTracker>> GetSickLeaves();
        Task<List<LeaveTracker>> GetCasualLeaves();
    }
}
