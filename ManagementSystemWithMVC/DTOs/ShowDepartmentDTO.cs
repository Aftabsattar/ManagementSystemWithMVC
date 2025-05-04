namespace ManagementSystemWithMVC.DTOs;

public class ShowDepartmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
}