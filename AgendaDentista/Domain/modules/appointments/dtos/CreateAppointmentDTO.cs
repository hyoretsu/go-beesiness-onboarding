namespace Domain.Modules.Appointments.DTOs;

public class CreateAppointmentDTO {
	public required string cpf;
	public required DateTime endTime;
	public required DateTime startTime;
}
