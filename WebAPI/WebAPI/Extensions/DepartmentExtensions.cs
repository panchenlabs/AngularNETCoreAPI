using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentDto AsDto(this Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                CreatedDate = department.CreatedDate
            };
        }
    }
}