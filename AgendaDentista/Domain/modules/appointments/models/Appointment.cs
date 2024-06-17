using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Patients.Models;

namespace Domain.Modules.Appointments.Models;

public class Appointment {
	public readonly Guid id;
	public readonly string patientCpf;
	public Patient? Paciente;
	public readonly DateTime startTime;
	public readonly DateTime endTime;
	public readonly DateTime createdAt;
	public readonly DateTime updatedAt;

	public Appointment(CreateAppointmentDTO data) {
		id = new Guid();
		startTime = data.startTime;
		endTime = data.endTime;
		patientCpf = data.cpf;
		createdAt = DateTime.Now;
		updatedAt = createdAt;
	}
}
