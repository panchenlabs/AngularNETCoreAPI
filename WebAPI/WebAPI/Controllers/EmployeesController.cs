using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository employeeRepository;
        private readonly IWebHostEnvironment environment;

        public EmployeesController(IEmployeesRepository employeeRepository, IWebHostEnvironment environment)
        {
            this.employeeRepository = employeeRepository;
            this.environment = environment;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = employeeRepository.GetEmployees().Select(employee => employee.AsDto());
            return employees;
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetEmployee(Guid id)
        {
            var employee = employeeRepository.GetEmployee(id);

            if (employee is null)
            {
                return NotFound();
            }

            return employee.AsDto();
        }

        [HttpPost]
        public ActionResult<EmployeeDto> CreateEmployee(EmployeeCreateDto createEmployeeDto)
        {
            Employee employee = new()
            {
                Id = Guid.NewGuid(),
                EmployeeId = employeeRepository.GetNextEmployeeId(),
                EmployeeName = createEmployeeDto.EmployeeName,
                Department = createEmployeeDto.Department,
                DateOfJoining = createEmployeeDto.DateOfJoining,
                PhotoFileName = createEmployeeDto.PhotoFileName,
                CreatedDate = DateTimeOffset.UtcNow
            };

            employeeRepository.CreateEmployee(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(Guid id, EmployeeUpdateDto updateEmployeeDto)
        {
            var existingEmployee = employeeRepository.GetEmployee(id);
            if (existingEmployee is null)
            {
                return NotFound();
            }
            Employee updatedEmployee = existingEmployee with
            {
                EmployeeName = updateEmployeeDto.EmployeeName,
                Department = updateEmployeeDto.Department,
                DateOfJoining = updateEmployeeDto.DateOfJoining,
                PhotoFileName = updateEmployeeDto.PhotoFileName
            };

            employeeRepository.UpdateEmployee(updatedEmployee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = employeeRepository.GetEmployee(id);
            if (existingEmployee is null)
            {
                return NotFound();
            }

            employeeRepository.DeleteEmployee(id);

            return NoContent();
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = environment.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}