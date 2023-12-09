using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public DepartmentService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> CrateDepartment(CreateDepartmentDto department)
        {
            var newDepartment = new Department
            {
                Name = department.Name,
                Budget = department.Budget,
                OwnsPrinter = department.OwnsPrinter,
                Location = department.Location
            };
            _db.Departments.Add(newDepartment);
            var result = await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateDepartment(UpdateDepartmentDto department)
        {
            var dbDepartment = await _db.Departments.Where(x => x.Id == department.Id).FirstOrDefaultAsync();
            if(dbDepartment == null)
            {
                return false;
            }
            dbDepartment.Budget = department.Budget;
            dbDepartment.OwnsPrinter = department.OwnsPrinter;
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<List<DepartmentDto>> GetDepartmentsWithXEmployees(int numOfEmployees)
        {
            return _mapper.Map<List<DepartmentDto>>(await _db.Departments.Include(x => x.Employees).Where(x => x.Employees.Count >= numOfEmployees).ToListAsync());
        }
    }
}
