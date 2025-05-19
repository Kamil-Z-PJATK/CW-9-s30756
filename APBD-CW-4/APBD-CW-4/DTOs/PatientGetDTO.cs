using APBD_CW_4.DTOs;

namespace APBD_CW_4.Models;

public class PatientGetDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public ICollection<PerscriptionGetPatientDTO> Prescriptions { get; set; }
}