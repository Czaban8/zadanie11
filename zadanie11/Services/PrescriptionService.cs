using Microsoft.EntityFrameworkCore;
using zadanie11.Data;
using zadanie11.DTOs;
using zadanie11.Models;

namespace zadanie11.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly DatabaseContext _context;
    public PrescriptionService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Prescription> CreatePrescription(PrescriptionDTO prescriptionDTO, int doctorId)
    {
        if (prescriptionDTO.Date > prescriptionDTO.DueDate)
        {
            throw new ArgumentException("DuteDate musi byc wiekszy niz date");
        }

        if (prescriptionDTO.Medicaments.Count > 10)
        {
            throw new ArgumentException("maks 10 lekow");
        }
        
        
        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PateintId == prescriptionDTO.Patient.PateintId && p.BirthDate == prescriptionDTO.Patient.BirthDate && p.FirstName == prescriptionDTO.Patient.FirstName && p.LastName == prescriptionDTO.Patient.LastName);

        if (patient == null)
        {
            patient = new Patient()
            {
                PateintId = prescriptionDTO.Patient.PateintId,
                FirstName = prescriptionDTO.Patient.FirstName,
                LastName = prescriptionDTO.Patient.LastName,
                BirthDate = prescriptionDTO.Patient.BirthDate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var medicamentIds = prescriptionDTO.Medicaments.Select(m => m.MedicamentId).ToList();
        var existing = await _context.Medicaments
            .Where(m => medicamentIds.Contains(m.MedicamentId))
            .Select(m => m.MedicamentId)
            .ToListAsync();

        var notFound = medicamentIds.Except(existing).ToList();
        if (notFound.Any())
            throw new ArgumentException($"Leki o ID: {string.Join(", ", notFound)} nie istnieją.");
        var prescription = new Prescription()
        {
            Date = prescriptionDTO.Date,
            DueDate = prescriptionDTO.DueDate,
            PatientId = patient.PateintId,
            DoctorId = doctorId,
            PrescriptionMedicaments = prescriptionDTO.Medicaments.Select(m => new PrescriptionMedicament
            {
                MedicamentId = m.MedicamentId,
                Dose = m.Dose,
                Details = m.Description
            }).ToList()
        };
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
        
        return prescription;
    }
}