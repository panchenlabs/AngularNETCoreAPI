using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Extensions;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsRepository departmentRepository;

        public DepartmentsController(IDepartmentsRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IEnumerable<DepartmentDto> GetDepartments()
        {
            var departments = departmentRepository.GetDepartments().Select(department => department.AsDto());
            return departments;
        }

        [HttpGet("{id}")]
        public ActionResult<DepartmentDto> GetDepartment(Guid id)
        {
            var department = departmentRepository.GetDepartment(id);

            if (department is null)
            {
                return NotFound();
            }

            return department.AsDto();
        }

        [HttpPost]
        public ActionResult<DepartmentDto> CreateDepartment(DepartmentCreateDto createDepartmentDto)
        {
            Department department = new()
            {
                Id = Guid.NewGuid(),
                DepartmentId = departmentRepository.GetNextDepartmentId(),
                DepartmentName = createDepartmentDto.DepartmentName,
                CreatedDate = DateTimeOffset.UtcNow
            };

            departmentRepository.CreateDepartment(department);

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(Guid id, DepartmentUpdateDto updateDepartmentDto)
        {
            var existingDepartment = departmentRepository.GetDepartment(id);
            if (existingDepartment is null)
            {
                return NotFound();
            }
            Department updatedDepartment = existingDepartment with
            {
                DepartmentName = updateDepartmentDto.DepartmentName
            };

            departmentRepository.UpdateDepartment(updatedDepartment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(Guid id)
        {
            var existingDepartment = departmentRepository.GetDepartment(id);
            if (existingDepartment is null)
            {
                return NotFound();
            }

            departmentRepository.DeleteDepartment(id);

            return NoContent();
        }
    }
}