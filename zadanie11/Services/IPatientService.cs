using zadanie11.DTOs;

namespace zadanie11.Services;

public interface IPatientService
{
    Task<PatientDetailsDto?> GetPatientDetailsAsync(int idPatient);

}