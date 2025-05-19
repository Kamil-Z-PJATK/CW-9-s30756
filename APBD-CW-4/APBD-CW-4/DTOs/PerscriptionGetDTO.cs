using APBD_CW_4.Models;

namespace APBD_CW_4.DTOs;

public class PerscriptionGetDTO
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public ICollection<Medicament> Meds { get; set; }
}