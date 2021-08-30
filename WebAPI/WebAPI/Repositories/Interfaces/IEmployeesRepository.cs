using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        int GetNextEmployeeId();

        Employee GetEmployee(Guid id);

        IEnumerable<Employee> GetEmployees();

        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Guid id);
    }
}