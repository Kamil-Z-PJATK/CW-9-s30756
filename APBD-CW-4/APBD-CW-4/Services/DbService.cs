using System.Data;
using APBD_CW_4.Data;
using APBD_CW_4.DTOs;
using APBD_CW_4.Exceptions;
using APBD_CW_4.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_CW_4.Services;

public class DbService(AppDbContext data):IDbService
{
    public async Task<PerscriptionGetDTO> AddPerscriptionAsync(PerscriptionCreateDTO perscription)
    {
       
        
        
        var transaction = await data.Database.BeginTransactionAsync();
        try
        {
            var ifPatient=data.Patients.FirstOrDefaultAsync(e=>e.IdPatient==perscription.Patient.IdPatient);
            if (await ifPatient == null)
            {
                data.Patients.Add(new Patient
                {
                    
                    FirstName = perscription.Patient.FirstName,
                    LastName = perscription.Patient.LastName,
                    BirthDate = perscription.Patient.BirthDate,

                });
            }
            await data.SaveChangesAsync();

            foreach (var med in perscription.Medicaments )
            {
                if (data.Medicaments.FirstOrDefaultAsync(e => e.IdMedicament == med.IdMedicament)==null)
                {
                    throw new MedicamentNotFoundException("Medicament not found");
                }
            }

            if (perscription.Date > perscription.DueDate)
            {
                throw new DataException("The date is earlier than the due date");
            }

            var per = new Prescription
                {
                    Date = perscription.Date,
                    DueDate = perscription.DueDate,
                    IdPatient = perscription.Patient.IdPatient,
                    IdDoctor = perscription.IdDoctor
                };
            data.Prescriptions.Add(per );
            await data.SaveChangesAsync();

            foreach (var med in perscription.Medicaments)
            {
                data.PrescriptionMedicaments.Add(new PrescriptionMedicament
                {
                    IdMedicament = med.IdMedicament,
                    IdPrescription = per.IdPrescription,
                    Dose= 100,
                    Details = "Tyle ile maszyna dała"
                    
                });
            }
            await data.SaveChangesAsync();
            
            await transaction.CommitAsync(); 
            return new PerscriptionGetDTO
            {
                IdPrescription = per.IdPrescription,
                Date = per.Date,
                DueDate = per.DueDate,
                IdPatient = per.IdPatient,
                IdDoctor = per.IdDoctor,
                Meds = perscription.Medicaments
            };
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw e;
        }

       
    }

    public async Task<PatientGetDTO> GetPatientAsync(int id)
    {
        
        var prescriptions = await data.Prescriptions.Join(data.Doctors,p=>p.IdDoctor,d=>d.IdDoctor,(p,d) => new {p,d})
                                            .Select(p=>new PerscriptionGetPatientDTO
                                            {
                                                IdPrescription = p.p.IdPrescription,
                                                Date = p.p.Date,
                                                DueDate = p.p.DueDate,
                                                Doctor = new Doctor
                                                {
                                                    IdDoctor = p.d.IdDoctor,
                                                    FirstName = p.d.FirstName,
                                                    LastName = p.d.LastName,
                                                    Email = p.d.Email,
                                                },
                                                Medicaments = data.Medicaments.Join(data.PrescriptionMedicaments, m=>m.IdMedicament,pm=>pm.IdMedicament,(m,pm) => new {m,pm})
                                                                .Where(e=>e.pm.IdPrescription==p.p.IdPrescription).Select(e=>new Medicament
                                                                {
                                                                    IdMedicament = e.pm.IdMedicament,
                                                                    Name = e.m.Name,
                                                                    Description = e.m.Description,
                                                                    Type = e.m.Type
                                                                }).ToList()
                                                
                                            }).ToListAsync();



        return new PatientGetDTO
        {
            IdPatient = id,
            FirstName = data.Patients.FirstOrDefault(e => e.IdPatient == id).FirstName,
            LastName = data.Patients.FirstOrDefault(e => e.IdPatient == id).LastName,
            DateOfBirth = data.Patients.FirstOrDefault(e => e.IdPatient == id).BirthDate,
            Prescriptions = prescriptions

        };
    }
}