using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(int id, Department department);
        Task DeleteDepartment(int id);
        Task<Department> GetDepartmentById(int id);
        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
