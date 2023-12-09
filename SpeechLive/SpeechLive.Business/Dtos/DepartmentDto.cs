using SpeechLive.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechLive.Business.Dtos
{
    public class DepartmentDto : BaseDto
    {
        [StringLength(1000, MinimumLength = 10)]
        public string Name { get; set; }

        public string Location { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Budget { get; set; }

        public bool OwnsPrinter { get; set; }
        public List<Employee> Employees { get; set; }
    }
}