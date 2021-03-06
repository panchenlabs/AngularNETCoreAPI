using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public record DepartmentDto
    {
        public Guid Id { get; init; }
        public int DepartmentId { get; init; }
        public string DepartmentName { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}