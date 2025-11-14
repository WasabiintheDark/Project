using System.ComponentModel.DataAnnotations;

namespace CompanyWorkload.Domain.DTO
{
    public class DepartmentReadDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
