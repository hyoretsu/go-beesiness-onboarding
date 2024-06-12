using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;

namespace Domain.Modules.Patients.Services;

public class ListPatientsByNameService(IPatientsRepository patientsRepository) {
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public IEnumerable<Patient> Execute() {
		Patient[] patients = patientsRepository.FindAll();
		Array.Sort(patients, new Patient.NameComparer());

		return patients;
	}
}
