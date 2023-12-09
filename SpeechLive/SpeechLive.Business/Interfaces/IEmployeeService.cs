using SpeechLive.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechLive.Business.Interfaces
{
    public interface IEmployeeService
    {
        public Task<bool> CreateEmployee(CreateEmployeeDto employee);
    }
}