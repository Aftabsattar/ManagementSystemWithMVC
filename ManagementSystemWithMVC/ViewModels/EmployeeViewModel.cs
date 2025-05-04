using System.ComponentModel.DataAnnotations;

namespace ManagementSystemWithMVC.ViewModels;

public class EmployeeViewModel
{
    [Key]
    [Required(ErrorMessage = "Employee ID is required.")]
    public int Id { get; set; }
   
    [Required(ErrorMessage = "Employee name is required.")]
    public string Name { get; set; } = string.Empty;
   
    [Required(ErrorMessage = "Employee email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;
   
    [Required(ErrorMessage = "Employee phone number is required.")]
    public string Phone { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Employee department ID is required.")]
    public int DepartmentId { get; set; }
    
    [Required(ErrorMessage = "Joining date is required.")]
    [DataType(DataType.Date)]
    public DateTime JoiningDate { get; set; }
}