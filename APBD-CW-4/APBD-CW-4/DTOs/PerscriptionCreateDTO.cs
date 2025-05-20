using System.ComponentModel.DataAnnotations;
using APBD_CW_4.Models;

namespace APBD_CW_4.DTOs;

public class PerscriptionCreateDTO
{
   
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public Patient Patient { get; set; }
    public int IdDoctor { get; set; }
    [MaxLength(10)]
    public ICollection<Medicament> Medicaments { get; set; }
}