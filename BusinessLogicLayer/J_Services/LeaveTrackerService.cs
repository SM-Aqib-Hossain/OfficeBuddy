using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.J_Services
{
    public class LeaveTrackerService : ILeaveTrackerService
    {
        private readonly ILeaveTrackerRepository _leaveTrackerRepository;

        public LeaveTrackerService(ILeaveTrackerRepository leaveTrackerRepository)
        {
            _leaveTrackerRepository = leaveTrackerRepository;
        }

        public async Task<LeaveTracker> AddLeave(LeaveTracker leaveTracker)
        {
            return await _leaveTrackerRepository.AddLeave(leaveTracker);
        }

        public async Task DeleteLeave(int id)
        {
            await _leaveTrackerRepository.DeleteLeave(id);
        }

        public async Task<List<LeaveTracker>> GetAllLeaves()
        {
            return await _leaveTrackerRepository.GetAllLeaves();
        }

        public async Task<List<LeaveTracker>> GetCasualLeaves()
        {
            return await _leaveTrackerRepository.GetCasualLeaves();
        }

        public async Task<LeaveTracker> GetLeaveById(int id)
        {
            return await _leaveTrackerRepository.GetLeaveById(id);
        }

        public async Task<List<LeaveTracker>> GetLeavesByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _leaveTrackerRepository.GetLeavesByDateRange(startDate, endDate);
        }

        public async Task<List<LeaveTracker>> GetLeavesByEmployeeId(int employeeId)
        {
            return await _leaveTrackerRepository.GetLeavesByEmployeeId(employeeId);
        }

        public async Task<List<LeaveTracker>> GetPendingLeaves()
        {
            return await _leaveTrackerRepository.GetPendingLeaves();
        }

        public async Task<List<LeaveTracker>> GetSickLeaves()
        {
            return await _leaveTrackerRepository.GetSickLeaves();
        }

        public async Task<LeaveTracker> UpdateLeave(int id, LeaveTracker leaveTracker)
        {
            return await _leaveTrackerRepository.UpdateLeave(id, leaveTracker);
        }
    }
}
