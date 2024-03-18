using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;

namespace Solid.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext dd)
        {
            _context = dd;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            Employee employee = new Employee();
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> PostAsync(Employee value)
        {
            _context.Employees.Add(value);
            await _context.SaveChangesAsync();
            return await _context.Employees.FindAsync(value.Id);
        }

        public async Task<Employee> PutAsync(int id, Employee value)
        {
            Employee employee;
            employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Active=value.Active;
                employee.FirstName=value.FirstName;
                employee.LastName=value.LastName;
                employee.DateOfBirth=value.DateOfBirth;
                employee.StartDate=value.StartDate;
                employee.Roles=value.Roles;
                employee.Gender=value.Gender;
                employee.Identity=value.Identity;

                await _context.SaveChangesAsync();
            }
            return employee;
        }
        public async Task<Employee> DeleteAsync(int id)
        {
            Employee employee;
            employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }
    }
}
