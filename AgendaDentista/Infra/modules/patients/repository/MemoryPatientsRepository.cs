using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;

namespace Infra.Modules.Patients.Repository;

public class MemoryPatientsRepository : IPatientsRepository {
	private IEnumerable<Patient> patients;

	public MemoryPatientsRepository() {
		patients = [];
	}

	public Patient Create(CreatePatientDTO data) {
		Patient patient = new(data);

		patients = patients.Append(patient);

		return patient;
	}

	public Patient[] FindAll() {
		return patients.ToArray();
	}

	public Patient? FindByCpf(string cpf) {
		Patient? patient = null;

		foreach (Patient storedPatient in patients) {
			if (storedPatient.cpf == cpf) {
				patient = storedPatient;
			}
		}

		return patient;
	}
}
