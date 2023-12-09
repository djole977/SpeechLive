using SpeechLive.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechLive.Business.Interfaces
{
    public interface IDepartmentService
    {
        public Task<bool> CrateDepartment(CreateDepartmentDto department);
        public Task<bool> UpdateDepartment(UpdateDepartmentDto department);
        public Task<List<DepartmentDto>> GetDepartmentsWithXEmployees(int numOfEmployees);
    }
}
