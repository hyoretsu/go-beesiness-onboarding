using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Shared.Exceptions;

namespace Domain.Modules.Patients.Services;

public class DeletePatientService(IPatientsRepository patientsRepository) {
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public void Execute(DeletePatientDTO data) {
		Patient? existingPatient = patientsRepository.FindByCpf(data.cpf);
		if (existingPatient == null) {
			throw new ApiException("Erro: paciente não cadastrado");
		}

		patientsRepository.Delete(data.cpf);
	}
}
