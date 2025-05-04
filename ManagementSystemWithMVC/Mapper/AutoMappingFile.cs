using AutoMapper;
using ManagementSystemWithMVC.DTOs;
using ManagementSystemWithMVC.Entities;
using ManagementSystemWithMVC.ViewModels;

namespace ManagementSystemWithMVC.Mapper;

public class AutoMappingFile: Profile
{
    public AutoMappingFile()
    {
        CreateMap<AddDepartmentDTO, Department>();
        CreateMap<Department, ShowDepartmentDTO>();
        CreateMap<AddEmployeeDTO, Employee>();
        CreateMap<Employee, ShowEmployeeDTO>();
        CreateMap<DepartmentViewModel,AddDepartmentDTO>();
        CreateMap<ShowDepartmentDTO, DepartmentViewModel>();
        CreateMap<ShowDepartmentDTO, DepartmentViewModel>();
        CreateMap<ShowEmployeeDTO,EmployeeViewModel>();
        CreateMap<EmployeeViewModel,AddEmployeeDTO>();
    }
}