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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Department> AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }

        public async Task DeleteDepartment(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Department Not found ");
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);

            if (department != null)
            {
                return department;
            }
            else
            {
                throw new KeyNotFoundException("Cutomer Not found ");
            }
        }

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            // Find the existing department by its ID
            var existingDepartment = await _dbContext.Departments.FindAsync(id);

            if (existingDepartment != null)
            {
                // Update the properties of the existing department
                existingDepartment.Name = department.Name;
                existingDepartment.Location = department.Location;

                // Optional: Update the EmployeeId list
                if (department.EmployeeId != null && department.EmployeeId.Any())
                {
                    // Validate that all Employee IDs exist in the database
                    var validEmployeeIds = new List<int>();
                    foreach (var employeeId in department.EmployeeId)
                    {
                        var employeeExists = await _dbContext.Employees.AnyAsync(e => e.Id == employeeId);
                        if (employeeExists)
                        {
                            validEmployeeIds.Add(employeeId);
                        }
                    }

                    // Update the EmployeeId list with valid IDs
                    existingDepartment.EmployeeId = validEmployeeIds;
                }
                else
                {
                    // If no EmployeeId list is provided, clear the current list
                    existingDepartment.EmployeeId = new List<int>();
                }

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Return the updated department
                return existingDepartment;
            }
            else
            {
                // Throw an exception if the department is not found
                throw new KeyNotFoundException("Department not found");
            }
        }

    }
}
