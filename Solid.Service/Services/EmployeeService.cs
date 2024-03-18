using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;

namespace Solid.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeService(IEmployeeRepository dd)
        {
            _EmployeeRepository = dd;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _EmployeeRepository.GetAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _EmployeeRepository.GetAsync(id);
        }

        public async Task<Employee> PostEmployeeAsync(Employee value)
        {
            return await _EmployeeRepository.PostAsync(value);
        }

        public async Task<Employee> PutEmployeeAsync(int id, Employee value)
        {
            return await _EmployeeRepository.PutAsync(id, value);
        }
        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            return await _EmployeeRepository.DeleteAsync(id);
        }
    }
}
