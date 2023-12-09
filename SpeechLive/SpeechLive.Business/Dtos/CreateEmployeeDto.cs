using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechLive.Business.Dtos
{
    public class CreateEmployeeDto
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Employee salary must be positive")]
        public decimal Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
