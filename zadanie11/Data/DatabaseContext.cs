using Microsoft.EntityFrameworkCore;
using zadanie11.Models;

namespace zadanie11.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    protected DatabaseContext()
    {

    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor() { DoctorId = 1, Email = "doctor1@gmail.com", FirstName = "Borys", LastName = "Dziuba" },
            new Doctor() { DoctorId = 2, Email = "doctor2@gmail.com", FirstName = "Szymek", LastName = "Basiak" },
            new Doctor() { DoctorId = 3, Email = "doctor3@gmail.com", FirstName = "Skibidi", LastName = "Toliet" }
        });
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient()
                { PateintId = 1, FirstName = "Bartosz", LastName = "Bialy", BirthDate = new DateTime(2003, 12, 17) },
            new Patient()
                { PateintId = 2, FirstName = "Patryk", LastName = "Basiak", BirthDate = new DateTime(2003, 10, 10) }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament()
                { MedicamentId = 1, Name = "Paracetamol", Description = "Paracetamol", Type = "Antybiotyczne" },
            new Medicament()
                { MedicamentId = 2, Name = "Ibuprofen", Description = "Ibuprofen", Type = "Antybiotyczne" },
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription() { PrescriptionId = 1, Date = new DateTime(2022, 01, 01), DueDate = new DateTime(2022, 02, 02), PatientId = 1, DoctorId = 1 },
            new Prescription() { PrescriptionId = 2, Date = new DateTime(2022, 03, 11), DueDate = new DateTime(2022, 04, 07), PatientId = 2, DoctorId = 1 },
            new Prescription() { PrescriptionId = 3, Date = new DateTime(2022, 4, 30), DueDate = new DateTime(2022, 06, 12), PatientId = 2, DoctorId = 3}
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament() {MedicamentId = 1, PrescriptionId = 1,Dose=4,Details = "lek jakis"},
            new PrescriptionMedicament() {MedicamentId = 2, PrescriptionId = 1,Dose=2,Details = "lek jakis 2" },
            new PrescriptionMedicament() {MedicamentId = 1, PrescriptionId = 2,Dose=1,Details = "lek jakis 3" },
            new PrescriptionMedicament() {MedicamentId = 2, PrescriptionId = 3,Dose=7,Details = "lek jakis 4" },
        });
    }
    
}