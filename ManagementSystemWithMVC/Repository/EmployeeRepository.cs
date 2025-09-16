﻿using AutoMapper;
using ManagementSystemWithMVC.Database;
using ManagementSystemWithMVC.DTOs;
using ManagementSystemWithMVC.Entities;
using ManagementSystemWithMVC.ExceptionHandling;
using ManagementSystemWithMVC.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemWithMVC.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public EmployeeRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AddEmployee(AddEmployeeDTO employee)
    {
        var result = await _context.Employees.AddAsync(_mapper.Map<Employee>(employee));
        if (result == null) throw new NotFoundException("Employee Not Found");
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee =await _context.Employees.FindAsync(id);
        if (employee == null) throw new NotFoundException("Employee Not Found");
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ShowEmployeeDTO>> GetAllEmployees()
    {
        var listEmployee = await _context.Employees.ToListAsync();
        if (listEmployee.Count == 0) throw new NotFoundException("Employees Not Found");
        return _mapper.Map<List<ShowEmployeeDTO>>(listEmployee);
    }

    public async Task<ShowEmployeeDTO> GetByIdEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) throw new NotFoundException("Employee Not Found");
        return _mapper.Map<ShowEmployeeDTO>(employee);
    }

    public async Task<bool> UpdateEmployee(int id, AddEmployeeDTO employee)
    {
        var updateEmployee =await _context.Employees.FindAsync(id);
        if (updateEmployee == null) throw new NotFoundException("Employee Not Found");
        _mapper.Map(employee, updateEmployee);
        _context.Employees.Update(updateEmployee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ShowEmployeeDTO>> GetByDepartmentId(int departmentId)
    {
        var employees = await _context.Employees.Where(e => e.DepartmentId == departmentId).ToListAsync();
        if (employees.Count == 0) throw new NotFoundException("Employees Not Found");
        return _mapper.Map<List<ShowEmployeeDTO>>(employees);
    }
}