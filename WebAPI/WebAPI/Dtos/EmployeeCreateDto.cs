using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public record EmployeeCreateDto
    {
        [Required]
        public string EmployeeName { get; init; }
        [Required]
        public string Department { get; init; }
        [Required]
        public DateTimeOffset DateOfJoining { get; init; }
        [Required]
        public string PhotoFileName { get; init; }
    }
}