using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Infra.Shared;

namespace Infra.Modules.Patients.Repository;

public class MemoryPatientsRepository : IPatientsRepository {
	private IEnumerable<Patient> Patients = Database.patient;

	public Patient Create(CreatePatientDTO data) {
		Patient patient = new(data);

		Patients = Patients.Append(patient);

		return patient;
	}

	public void Delete(string cpf) {
		Patients = Patients.Where(patient => patient.cpf != cpf);
	}

	public IEnumerable<Patient> FindAll() {
		IEnumerable<Patient> patients = Patients;

		foreach (Patient patient in patients) {
			patient.Agendamentos = Database.appointment.Where(appointment => appointment.patientCpf == patient.cpf);
		};

		return patients;
	}

	public Patient? FindByCpf(string cpf) {
		Patient? patient = null;

		foreach (Patient storedPatient in Patients) {
			if (storedPatient.cpf == cpf) {
				patient = storedPatient;
			}
		}

		return patient;
	}
}
