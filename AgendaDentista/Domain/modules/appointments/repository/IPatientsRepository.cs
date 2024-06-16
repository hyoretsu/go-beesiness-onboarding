using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;

namespace Domain.Modules.Appointments.Repository;

public interface IAppointmentsRepository {
	public Appointment Create(CreateAppointmentDTO data);
	public void DeleteByCpf(string cpf);
	public IEnumerable<Appointment> FindByCpf(string cpf);
	public Appointment? FindExisting(FindExistingAppointmentDTO data);
}
