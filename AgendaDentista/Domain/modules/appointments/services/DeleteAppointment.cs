using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Repository;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Shared.Exceptions;

namespace Domain.Modules.Appointments.Services;

public class DeleteAppointmentService(IAppointmentsRepository appointmentsRepository, IPatientsRepository patientsRepository) {
	private readonly IAppointmentsRepository appointmentsRepository = appointmentsRepository;
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public void Execute(DeleteAppointmentDTO data) {
		Patient? patient = patientsRepository.FindByCpf(data.cpf);
		if (patient == null) {
			throw new ApiException("Paciente não cadastrado.");
		}

		try {
			appointmentsRepository.Delete(new DeleteAppointmentDTO {
				cpf = data.cpf,
				startTime = data.startTime
			});
		} catch {
			throw new ApiException("Agendamento não encontrado.");
		}
	}
}
