using ManagementSystemWithMVC.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementSystemWithMVC.ViewModels;

public class ListDepartamentViewModel
{
    public int Id { get; set; }

    public List<SelectListItem> Departments { get; set; } = new();
   
    // Changed to use view model instead of entity for presentation
    public List<EmployeeViewModel> Employees { get; set; } = new();
}