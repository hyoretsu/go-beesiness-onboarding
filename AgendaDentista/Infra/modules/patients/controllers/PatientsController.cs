using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Modules.Patients.Services;
using Infra.Modules.Patients.Repository;

namespace Infra.Modules.Patients.Controllers;

public static class PatientsController {
	public static readonly IPatientsRepository patientsRepository = new MemoryPatientsRepository();

	public static readonly CreatePatientService createPatient = new(patientsRepository);
	public static readonly ListPatientsByNameService listPatientsByName = new(patientsRepository);

	public static Patient Create(CreatePatientDTO data) {
		Patient patient = createPatient.Execute(data);

		return patient;
	}

	public static IEnumerable<Patient> ListByName() {
		IEnumerable<Patient> patients = listPatientsByName.Execute();

		return patients;
	}
}
