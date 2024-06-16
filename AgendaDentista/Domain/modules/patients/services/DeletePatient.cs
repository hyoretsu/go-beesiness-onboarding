using Domain.Modules.Appointments.Repository;
using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Shared.Exceptions;

namespace Domain.Modules.Patients.Services;

public class DeletePatientService(IAppointmentsRepository appointmentsRepository, IPatientsRepository patientsRepository) {
	private readonly IAppointmentsRepository appointmentsRepository = appointmentsRepository;
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public void Execute(DeletePatientDTO data) {
		Patient? existingPatient = patientsRepository.FindByCpf(data.cpf);
		if (existingPatient == null) {
			throw new ApiException("Erro: paciente não cadastrado");
		}

		appointmentsRepository.DeleteByCpf(data.cpf);
		patientsRepository.Delete(data.cpf);
	}
}
