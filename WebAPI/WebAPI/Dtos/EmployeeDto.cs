using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public record EmployeeDto
    {
        public Guid Id { get; init; }
        public int EmployeeId { get; init; }
        public string EmployeeName { get; init; }
        public string Department { get; init; }
        public DateTimeOffset DateOfJoining { get; init; }
        public string PhotoFileName { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}