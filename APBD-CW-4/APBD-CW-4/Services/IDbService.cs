using APBD_CW_4.DTOs;
using APBD_CW_4.Models;

namespace APBD_CW_4.Services;

public interface IDbService
{
    public Task<PerscriptionGetDTO> AddPerscriptionAsync(PerscriptionCreateDTO perscription);
    public Task<PatientGetDTO> GetPatientAsync(int id);
}