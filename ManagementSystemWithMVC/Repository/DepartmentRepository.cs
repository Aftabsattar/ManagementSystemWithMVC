using AutoMapper;
using ManagementSystemWithMVC.Database;
using ManagementSystemWithMVC.DTOs;
using ManagementSystemWithMVC.Entities;
using ManagementSystemWithMVC.ExceptionHandling;
using ManagementSystemWithMVC.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemWithMVC.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public DepartmentRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AddDepartment(AddDepartmentDTO addDepartmentDTO)
    {
        await _context.Departments.AddAsync(_mapper.Map<Department>(addDepartmentDTO));
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null)  throw new NotFoundException("Department Not Found");
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ShowDepartmentDTO>> GetAllDepartments()
    {
        var allDepartment = await _context.Departments.ToListAsync();
        if (allDepartment.Count == 0) throw new NotFoundException("No departments found");
        return _mapper.Map<List<ShowDepartmentDTO>>(allDepartment);
    }

    public async Task<ShowDepartmentDTO> GetByIdDepartment(int id)
    {
        var depart = await _context.Departments.FindAsync(id);
        if (depart == null) throw new NotFoundException("Department Not Found");
        return _mapper.Map<ShowDepartmentDTO>(depart);
    }

    public async Task<bool> UpdateDepartment(int id, AddDepartmentDTO addDepartmentDTO)
    {
        var department =await _context.Departments.FindAsync(id);
        if (department == null) throw new NotFoundException("Department Not Found For Update");
        _mapper.Map(addDepartmentDTO, department);
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return true;
    }
}