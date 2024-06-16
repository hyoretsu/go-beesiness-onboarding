using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Appointments.Repository;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Shared.Exceptions;

namespace Domain.Modules.Appointments.Services;

public class CreateAppointmentService(IAppointmentsRepository appointmentsRepository, IPatientsRepository patientsRepository) {
	private readonly IAppointmentsRepository appointmentsRepository = appointmentsRepository;
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public Appointment Execute(CreateAppointmentDTO data) {
		if (data.startTime <= DateTime.Now) {
			throw new ApiException("Agendamentos só podem ser marcados para uma data futura.");
		}

		if (data.endTime < data.startTime) {
			throw new ApiException("O término do agendamento não pode ocorrer antes do início.");
		}

		Patient? patient = patientsRepository.FindByCpf(data.cpf);
		if (patient == null) {
			throw new ApiException("Paciente não cadastrado.");
		}

		IEnumerable<Appointment> appointments = appointmentsRepository.FindByCpf(data.cpf);
		foreach (Appointment storedAppointment in appointments) {
			if (storedAppointment.startTime > DateTime.Now) {
				throw new ApiException("Cada paciente só pode realizar um agendamento futuro por vez");
			}
		}

		Appointment? existingAppointment = appointmentsRepository.FindExisting(new FindExistingAppointmentDTO {
			endTime = data.endTime,
			startTime = data.startTime
		});
		if (existingAppointment != null) {
			throw new ApiException("Já existe uma consulta agendada nesse horário.");
		}

		Appointment appointment = appointmentsRepository.Create(new CreateAppointmentDTO {
			cpf = data.cpf,
			endTime = data.endTime,
			startTime = data.startTime
		});

		return appointment;
	}
}
