using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> AddAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync(int id, Attendance attendance);
        Task DeleteAttendanceAsync(int id);
        Task<Attendance> GetAttendanceById(int id);
        Task<List<Attendance>> GetAllAttendancesAsync();
        Task<List<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId);
        Task<List<Attendance>> GetAttendancesByStatusAsync(string status);
    }
}
