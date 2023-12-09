using AutoMapper;
using SpeechLive.Business.Dtos;
using SpeechLive.Data.Models;

namespace UpravnicaNILocal.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BaseModel, BaseDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}