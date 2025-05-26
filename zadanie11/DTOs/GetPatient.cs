namespace zadanie11.DTOs;


public class PatientDetailsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public List<PrescriptionDto> Prescriptions { get; set; }
    
}

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentsDto> Medicaments { get; set; }
    public DoctorDto Doctor { get; set; }
}

public class MedicamentsDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}