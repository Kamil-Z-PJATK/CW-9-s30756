using APBD_CW_4.Models;

namespace APBD_CW_4.DTOs;

public class PerscriptionGetPatientDTO
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<Medicament> Medicaments { get; set; }
}