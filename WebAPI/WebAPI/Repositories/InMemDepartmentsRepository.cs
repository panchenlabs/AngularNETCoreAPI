using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class InMemDepartmentsRepository : IDepartmentsRepository
    {
        private readonly List<Department> departments = new()
        {
            new Department() { Id = Guid.NewGuid(), DepartmentId = 1, DepartmentName = "IT", CreatedDate = DateTimeOffset.UtcNow },
            new Department() { Id = Guid.NewGuid(), DepartmentId = 2, DepartmentName = "Support", CreatedDate = DateTimeOffset.UtcNow },
        };

        public int GetNextDepartmentId()
        {
            var maxId = departments.Select(department => department.DepartmentId).DefaultIfEmpty().Max();
            return maxId + 1;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return departments;
        }

        public Department GetDepartment(Guid id)
        {
            return departments.Where(department => department.Id == id).SingleOrDefault();
        }

        public void CreateDepartment(Department department)
        {
            departments.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            var index = departments.FindIndex(existingDepartment => existingDepartment.Id == department.Id);
            departments[index] = department;
        }

        public void DeleteDepartment(Guid id)
        {
            var index = departments.FindIndex(existingDepartment => existingDepartment.Id == id);
            departments.RemoveAt(index);
        }
    }
}