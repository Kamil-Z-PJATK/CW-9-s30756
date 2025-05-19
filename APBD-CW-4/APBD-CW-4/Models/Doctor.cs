using System.ComponentModel.DataAnnotations;

namespace APBD_CW_4.Models;

public class Doctor
{
    [Key] public int IdDoctor { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [MaxLength(100)]
    public string Email { get; set; } = null!;
}