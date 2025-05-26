using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie11.Models;

[Table( "Prescription" )]
public class Prescription
{
    [Key]
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }

    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}