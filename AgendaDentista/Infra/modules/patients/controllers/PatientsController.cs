using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Modules.Patients.Services;
using Infra.Modules.Patients.Repository;
using Infra.Shared;

namespace Infra.Modules.Patients.Controllers;

public static class PatientsController {
	private static readonly CreatePatientService createPatient = new(SingletonClasses.patientsRepository);
	private static readonly DeletePatientService deletePatient = new(SingletonClasses.appointmentsRepository, SingletonClasses.patientsRepository);
	private static readonly ListPatientsByCpfService listPatientsByCpf = new(SingletonClasses.patientsRepository);
	private static readonly ListPatientsByNameService listPatientsByName = new(SingletonClasses.patientsRepository);

	public static Patient Create(CreatePatientDTO data) {
		Patient patient = createPatient.Execute(data);

		return patient;
	}

	public static void Delete(DeletePatientDTO data) {
		deletePatient.Execute(data);
	}

	public static IEnumerable<Patient> ListByCpf() {
		IEnumerable<Patient> patients = listPatientsByCpf.Execute();

		return patients;
	}

	public static IEnumerable<Patient> ListByName() {
		IEnumerable<Patient> patients = listPatientsByName.Execute();

		return patients;
	}
}
