using AutoMapper;
using ManagementSystemWithMVC.DTOs;
using ManagementSystemWithMVC.IGenericRepository;
using ManagementSystemWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemWithMVC.Controllers;


public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var employees = await _employeeRepository.GetAllEmployees();
        var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees);
        return View(employeeViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }   
    [HttpPost]
    public async Task<IActionResult> Add(EmployeeViewModel employeeViewModel)
    {
        if (ModelState.IsValid)
        {
            var employeeDTO = _mapper.Map<AddEmployeeDTO>(employeeViewModel);
            await _employeeRepository.AddEmployee(employeeDTO);
            return RedirectToAction("List");
        }
        return View(employeeViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _employeeRepository.DeleteEmployee(id);
        if (result)
        {
            return RedirectToAction("List");
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _employeeRepository.GetByIdEmployee(id);
       var resultDTO = _mapper.Map<EmployeeViewModel>(result);
        return View(resultDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EmployeeViewModel employeeViewModel)
    {
        if (ModelState.IsValid)
        {
            var employeeDTO = _mapper.Map<AddEmployeeDTO>(employeeViewModel);
            var result = await _employeeRepository.UpdateEmployee(id, employeeDTO);
            if (result)
            {
                return RedirectToAction("List");
            }
        }
        return View(employeeViewModel);
    }
}