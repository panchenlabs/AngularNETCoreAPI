using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto AsDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Department = employee.Department,
                DateOfJoining = employee.DateOfJoining,
                PhotoFileName = employee.PhotoFileName,
                CreatedDate = employee.CreatedDate
            };
        }
    }
}