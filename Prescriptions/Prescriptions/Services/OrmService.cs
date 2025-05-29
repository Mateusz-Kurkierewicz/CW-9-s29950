using Microsoft.EntityFrameworkCore;
using Prescriptions.DAL;
using Prescriptions.Exceptions;
using Prescriptions.Models;
using Prescriptions.Models.DTOs;

namespace Prescriptions.Services;

public class OrmService(PrescriptionsDbContext data) : IPrescriptionService
{
    public async Task<int> AddPrescriptionAsync(PrescriptionPostDto request, CancellationToken cancellationToken)
    {
        if (request.DueDate < DateTime.Now)
            throw new BadRequestException("Data podana na recepcie nie może być wcześniejsza niż aktualna!");
        if (request.Medicaments.Count > 10)
            throw new BadRequestException("Recepta może obejmować maksymalnie 10 leków!");
        foreach (var prescriptionMedicament in request.Medicaments)
        {
            var medicament = await data.Medicaments.Select(m => new MedicamentGetDto
            {
                IdMedicament = m.IdMedicament,
                Name = m.Name,
                Description = m.Description,
                Type = m.Type
            }).FirstOrDefaultAsync(m => m.IdMedicament == prescriptionMedicament.IdMedicament, cancellationToken);
            if (medicament == null)
                throw new NotFoundException($"Nie odnaleziono leku o id: {prescriptionMedicament.IdMedicament}!");
        }
        var patient = await data.Patients.Select(p => new PatientGetDto
        {
            IdPatient = p.IdPatient,
            FirstName = p.FirstName,
            LastName = p.LastName,
            BirthDate = p.BirthDate
        }).FirstOrDefaultAsync(p => p.FirstName == request.Patient.FirstName && p.LastName == request.Patient.LastName, cancellationToken);
        if (patient == null)
        {
            var transaction = await data.Database.BeginTransactionAsync(cancellationToken); // Begin transaction
            try
            {
                var newPatient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    BirthDate = request.Patient.BirthDate
                };
                await data.Patients.AddAsync(newPatient, cancellationToken);
                await data.SaveChangesAsync(cancellationToken);

                var prescription = new Prescription
                {
                    Date = DateTime.Now,
                    DueDate = request.DueDate,
                    IdPatient = newPatient.IdPatient,
                    IdDoctor = request.IdDoctor
                };
                await data.Prescriptions.AddAsync(prescription, cancellationToken);
                await data.SaveChangesAsync(cancellationToken);

                foreach (var medicament in request.Medicaments)
                {
                    var m = new PrescriptionMedicament(medicament.IdMedicament, prescription.IdPrescription, medicament.Dose, medicament.Details);
                    await data.PrescriptionMedicaments.AddAsync(m, cancellationToken);
                    await data.SaveChangesAsync(cancellationToken);
                }
                
                await transaction.CommitAsync(cancellationToken);
                return prescription.IdPrescription;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
        else
        {
            var transaction = await data.Database.BeginTransactionAsync(cancellationToken); // Begin transaction
            try
            {

                var prescription = new Prescription
                {
                    Date = DateTime.Now,
                    DueDate = request.DueDate,
                    IdPatient = patient.IdPatient,
                    IdDoctor = request.IdDoctor
                };
                await data.Prescriptions.AddAsync(prescription, cancellationToken);
                await data.SaveChangesAsync(cancellationToken);

                foreach (var medicament in request.Medicaments)
                {
                    var m = new PrescriptionMedicament(medicament.IdMedicament, prescription.IdPrescription, medicament.Dose, medicament.Details);
                    await data.PrescriptionMedicaments.AddAsync(m, cancellationToken);
                    await data.SaveChangesAsync(cancellationToken);
                }
                
                await transaction.CommitAsync(cancellationToken);
                return prescription.IdPrescription;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }

    public async Task<PatientGetDto> GetPatientAsync(int id, CancellationToken cancellationToken)
    {
        var result = await data.Patients.Select(p => new PatientGetDto
        {
            IdPatient = p.IdPatient,
            FirstName = p.FirstName,
            LastName = p.LastName,
            BirthDate = p.BirthDate,
            Prescriptions = p.Prescriptions.Select(pr => new PrescriptionGetDto
            {
                IdPrescription = pr.IdPrescription,
                Date = pr.Date,
                DueDate = pr.DueDate,
                Doctor = new DoctorGetDto
                {
                    IdDoctor = pr.Doctor.IdDoctor,
                    FirstName = pr.Doctor.FirstName,
                    LastName = pr.Doctor.LastName,
                    Email = pr.Doctor.Email
                },
                Medicaments = pr.PrescriptionMedicaments.Select(prm => new MedicamentGetDto
                {
                    IdMedicament = prm.Medicament.IdMedicament,
                    Name = prm.Medicament.Name,
                    Description = prm.Medicament.Description,
                    Type = prm.Medicament.Type
                }).ToList()
            }).OrderBy(o => o.DueDate).ToList()
        }).FirstOrDefaultAsync(s => s.IdPatient == id, cancellationToken);
        return result ?? throw new NotFoundException($"Nie odnaleziono pacjenta o id: {id}!");
    }
    
}