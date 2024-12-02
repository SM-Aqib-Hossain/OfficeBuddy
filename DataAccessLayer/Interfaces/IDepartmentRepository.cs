using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(int id, Department department);
        Task DeleteDepartment(int id);
        Task<Department> GetDepartmentById(int id);
        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
