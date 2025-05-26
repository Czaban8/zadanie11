namespace zadanie11.DTOs;

public class PrescriptionDTO
{
    public PatientDTO Patient { get; set; }
    
    public List<MedicamentDTO> Medicaments { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class PatientDTO
{
    public int PateintId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class MedicamentDTO
{
    public int MedicamentId { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}

