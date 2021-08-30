using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class InMemEmployeesRepository : IEmployeesRepository
    {
        private readonly List<Employee> employees = new()
        {
        };

        public int GetNextEmployeeId()
        {
            var maxId = employees.Select(employee => employee.EmployeeId).DefaultIfEmpty().Max();
            return maxId + 1;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.Where(employee => employee.Id == id).SingleOrDefault();
        }

        public void CreateEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var index = employees.FindIndex(existingEmployee => existingEmployee.Id == employee.Id);
            employees[index] = employee;
        }

        public void DeleteEmployee(Guid id)
        {
            var index = employees.FindIndex(existingEmployee => existingEmployee.Id == id);
            employees.RemoveAt(index);
        }
    }
}