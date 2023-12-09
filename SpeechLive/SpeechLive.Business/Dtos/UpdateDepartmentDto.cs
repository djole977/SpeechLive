using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechLive.Business.Dtos
{
    public class UpdateDepartmentDto
    {
        [Required]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Budget { get; set; }

        public bool OwnsPrinter { get; set; }
    }
}
