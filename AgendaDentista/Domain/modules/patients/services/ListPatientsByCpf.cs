using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;

namespace Domain.Modules.Patients.Services;

public class ListPatientsByCpfService(IPatientsRepository patientsRepository) {
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public IEnumerable<Patient> Execute() {
		Patient[] patients = patientsRepository.FindAll();
		Array.Sort(patients, new Patient.CpfComparer());

		return patients;
	}
}
