using AutoMapper;
using SpeechLive.Business.Dtos;
using SpeechLive.Business.Interfaces;
using SpeechLive.Data.Data;
using SpeechLive.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechLive.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public EmployeeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> CreateEmployee(CreateEmployeeDto employee)
        {
            var newEmployee = new Employee
            {
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };
            _db.Employees.Add(newEmployee);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
