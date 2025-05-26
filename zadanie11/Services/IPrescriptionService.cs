using zadanie11.DTOs;
using zadanie11.Models;

namespace zadanie11.Services;

public interface IPrescriptionService
{
    Task<Prescription> CreatePrescription(PrescriptionDTO prescriptionDTO, int doctorId);
}