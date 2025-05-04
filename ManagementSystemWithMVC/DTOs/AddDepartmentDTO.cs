using System.ComponentModel.DataAnnotations;

namespace ManagementSystemWithMVC.DTOs;

public class AddDepartmentDTO
{
    [Key]
    [Required(ErrorMessage = "Department ID is required.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Department name is required.")]
    public string Name { get; set; } = string.Empty;

    public string? Location { get; set; }
}