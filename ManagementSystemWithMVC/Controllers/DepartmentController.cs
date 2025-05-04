using AutoMapper;
using ManagementSystemWithMVC.DTOs;
using ManagementSystemWithMVC.IGenericRepository;
using ManagementSystemWithMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemWithMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository , IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public IActionResult AddDepartment()
        {
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var listDepartment = await _departmentRepository.GetAllDepartments();
            var showDepartment = _mapper.Map<List<DepartmentViewModel>>(listDepartment);
            return View(showDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentViewModel addDepartment)
        {
           
            var addDepartmentDTO = _mapper.Map<AddDepartmentDTO>(addDepartment);
            await _departmentRepository.AddDepartment(addDepartmentDTO);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentRepository.DeleteDepartment(id);
            if (result)
            {
                return RedirectToAction("GetAllDepartment");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdDepartment(id);
            var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);
            return View(departmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel addDepartment)
        {
            var addDepartmentDTO = _mapper.Map<AddDepartmentDTO>(addDepartment);
            var result = await _departmentRepository.UpdateDepartment(id, addDepartmentDTO);
            if (result)
            {
                return RedirectToAction("GetAllDepartment");
            }
            return View(addDepartment);
        }
    }
}
