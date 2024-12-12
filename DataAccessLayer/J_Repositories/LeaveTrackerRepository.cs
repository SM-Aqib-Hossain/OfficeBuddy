using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.J_Repositories
{
    public class LeaveTrackerRepository : ILeaveTrackerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LeaveTrackerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveTracker> AddLeave(LeaveTracker leaveTracker)
        {
            _dbContext.LeaveTrackers.Add(leaveTracker);
            await _dbContext.SaveChangesAsync();
            return leaveTracker;
        }

        public async Task DeleteLeave(int id)
        {
            var leaveTracker = await _dbContext.LeaveTrackers.FindAsync(id);
            if (leaveTracker != null)
            {
                _dbContext.LeaveTrackers.Remove(leaveTracker);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Leave record not found");
            }
        }

        public async Task<List<LeaveTracker>> GetAllLeaves()
        {
            return await _dbContext.LeaveTrackers.ToListAsync();
        }

        public async Task<LeaveTracker> GetLeaveById(int id)
        {
            var leaveTracker = await _dbContext.LeaveTrackers.FirstOrDefaultAsync(l => l.Id == id);
            if (leaveTracker != null)
            {
                return leaveTracker;
            }
            else
            {
                throw new KeyNotFoundException("Leave record not found");
            }
        }

        public async Task<List<LeaveTracker>> GetLeavesByEmployeeId(int employeeId)
        {
            return await _dbContext.LeaveTrackers.Where(l => l.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<List<LeaveTracker>> GetLeavesByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.LeaveTrackers.Where(l => l.LeaveDate >= startDate && l.LeaveDate <= endDate).ToListAsync();
        }

        public async Task<List<LeaveTracker>> GetSickLeaves()
        {
            return await _dbContext.LeaveTrackers.Where(l => l.LeaveType == "Sick").ToListAsync();
        }

        public async Task<List<LeaveTracker>> GetCasualLeaves()
        {
            return await _dbContext.LeaveTrackers.Where(l => l.LeaveType == "Casual").ToListAsync();
        }

        public async Task<List<LeaveTracker>> GetPendingLeaves()
        {
            return await _dbContext.LeaveTrackers.Where(l => l.Status == "Pending").ToListAsync();
        }

        public async Task<LeaveTracker> UpdateLeave(int id, LeaveTracker leaveTracker)
        {
            var existingLeave = await _dbContext.LeaveTrackers.FindAsync(id);
            if (existingLeave != null)
            {
                existingLeave.LeaveDate = leaveTracker.LeaveDate;
                existingLeave.LeaveType = leaveTracker.LeaveType;
                existingLeave.Reason = leaveTracker.Reason;
                existingLeave.Status = leaveTracker.Status;
                existingLeave.RequestDate = leaveTracker.RequestDate;
                existingLeave.ApprovalDate = leaveTracker.ApprovalDate;
                existingLeave.DaysRequested = leaveTracker.DaysRequested;

                await _dbContext.SaveChangesAsync();
                return existingLeave;
            }
            else
            {
                throw new KeyNotFoundException("Leave record not found");
            }
        }
    }
}
