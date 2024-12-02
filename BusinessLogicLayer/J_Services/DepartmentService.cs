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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            return await _departmentRepository.AddDepartment(department);
        }

        public async Task DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartment(id);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetDepartmentById(id);
        }

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            return await _departmentRepository.UpdateDepartment(id, department);
        }
    }
}
