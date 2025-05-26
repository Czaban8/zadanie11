using Microsoft.EntityFrameworkCore;
using zadanie11.Data;
using zadanie11.DTOs;
using zadanie11.Models;

namespace zadanie11.Services;

public class PatientService : IPatientService
{
    private readonly DatabaseContext _context;

    public PatientService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<PatientDetailsDto?> GetPatientDetailsAsync(int idPatient)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.PateintId == idPatient);

        if (patient == null)
            return null;

        return new PatientDetailsDto
        {
            IdPatient = patient.PateintId,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Prescriptions = patient.Prescriptions
                .OrderBy(pr => pr.DueDate)
                .Select(pr => new PrescriptionDto
                {
                    IdPrescription = pr.PrescriptionId,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Doctor = new DoctorDto
                    {
                        IdDoctor = pr.Doctor.DoctorId,
                        FirstName = pr.Doctor.FirstName
                    },
                    Medicaments = pr.PrescriptionMedicaments
                        .Select(pm => new MedicamentsDto
                        {
                            IdMedicament = pm.Medicament.MedicamentId,
                            Name = pm.Medicament.Name,
                            Dose = pm.Dose.ToString(), // bo string
                            Description = pm.Details
                        }).ToList()
                }).ToList()
        };
    }
}