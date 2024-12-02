using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.J_Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttendanceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
        {
            _dbContext.Attendances.Add(attendance);
            await _dbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _dbContext.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _dbContext.Attendances.Remove(attendance);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Attendance not found");
            }
        }

        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            return await _dbContext.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetAttendanceById(int id)
        {
            var attendance = await _dbContext.Attendances.FirstOrDefaultAsync(a => a.Id == id);
            if (attendance != null)
            {
                return attendance;
            }
            else
            {
                throw new KeyNotFoundException("Attendance not found");
            }
        }

        public async Task<Attendance> UpdateAttendanceAsync(int id, Attendance attendance)
        {
            var existingAttendance = await _dbContext.Attendances.FindAsync(id);
            if (existingAttendance != null)
            {
                existingAttendance.Date = attendance.Date;
                existingAttendance.EntryTime = attendance.EntryTime;
                existingAttendance.ExitTime = attendance.ExitTime;
                existingAttendance.Status = attendance.Status;

                await _dbContext.SaveChangesAsync();
                return existingAttendance;
            }
            else
            {
                throw new KeyNotFoundException("Attendance not found");
            }
        }

        public async Task<List<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId)
        {
            return await _dbContext.Attendances.Where(a => a.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendancesByStatusAsync(string status)
        {
            return await _dbContext.Attendances.Where(a => a.Status == status).ToListAsync();
        }
    }
}
