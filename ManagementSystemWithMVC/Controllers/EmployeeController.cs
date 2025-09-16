using AutoMapper;
using ManagementSystemWithMVC.DTOs;
using ManagementSystemWithMVC.IGenericRepository;
using ManagementSystemWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementSystemWithMVC.Controllers;


public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
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

    // View to select department and list employees
    [HttpGet]
    public async Task<IActionResult> GetListByDepartmentId(int? id)
    {
        var vm = new ListDepartamentViewModel();
        // populate departments
        var departments = await _departmentRepository.GetAllDepartments();
        vm.Departments = departments
            .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            .ToList();

        if (id.HasValue && id.Value > 0)
        {
            vm.Id = id.Value;
            try
            {
                var employees = await _employeeRepository.GetByDepartmentId(id.Value);
                vm.Employees = _mapper.Map<List<EmployeeViewModel>>(employees);
            }
            catch
            {
                // ignore not found for empty list scenario
                vm.Employees = new List<EmployeeViewModel>();
            }
        }
        return View(vm);
    }

    [HttpPost]
    public IActionResult GetListByDepartmentId(ListDepartamentViewModel model)
    {
        if (model.Id > 0)
        {
            return RedirectToAction(nameof(GetListByDepartmentId), new { id = model.Id });
        }
        return RedirectToAction(nameof(GetListByDepartmentId));
    }
}