using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.J_Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
        {
            return await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            await _attendanceRepository.DeleteAttendanceAsync(id);
        }

        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceById(id);
        }

        public async Task<List<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId)
        {

            return await _attendanceRepository.GetAttendancesByEmployeeIdAsync(employeeId);
        }
        public async Task<Attendance> UpdateAttendanceAsync(int id, Attendance attendance)
        {
            return await _attendanceRepository.UpdateAttendanceAsync(id, attendance);
        }
        public async Task<List<Attendance>> GetAttendancesByStatusAsync(string status)
        {
            return await _attendanceRepository.GetAttendancesByStatusAsync(status);
        }
    }
}
