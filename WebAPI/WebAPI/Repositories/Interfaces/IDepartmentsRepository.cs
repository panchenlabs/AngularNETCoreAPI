using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IDepartmentsRepository
    {
        int GetNextDepartmentId();

        Department GetDepartment(Guid id);

        IEnumerable<Department> GetDepartments();

        void CreateDepartment(Department department);

        void UpdateDepartment(Department department);

        void DeleteDepartment(Guid id);
    }
}