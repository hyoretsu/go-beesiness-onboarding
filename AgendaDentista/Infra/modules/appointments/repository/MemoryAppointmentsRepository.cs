using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Appointments.Repository;

namespace Infra.Modules.Appointments.Repository;

public class MemoryAppointmentsRepository : IAppointmentsRepository {
	public IEnumerable<Appointment> Appointments { get; private set; }

	public MemoryAppointmentsRepository() {
		Appointments = [];
	}

	public Appointment Create(CreateAppointmentDTO data) {
		Appointment appointment = new(data);

		Appointments = Appointments.Append(appointment);

		return appointment;
	}

	public void DeleteByCpf(string cpf) {
		Appointments = Appointments.Where(appointment => appointment.patientCpf != cpf);
	}

	public IEnumerable<Appointment> FindByCpf(string cpf) {
		IEnumerable<Appointment> foundAppointments = Appointments.Where(appointment => appointment.patientCpf == cpf);

		return foundAppointments;
	}

	public Appointment? FindExisting(FindExistingAppointmentDTO data) {
		Appointment? existingAppointment = null;

		foreach (Appointment appointment in Appointments) {
			// Same start/end time and start/end overlaps
			if (
				data.startTime == appointment.startTime ||
				data.endTime == appointment.endTime ||
				// Included or including the current appointment
				((data.startTime > appointment.startTime || data.endTime > appointment.endTime) && data.startTime < appointment.endTime) ||
				(data.startTime < appointment.startTime && data.endTime > appointment.startTime)
			) {
				existingAppointment = appointment;
			}
		}

		return existingAppointment;
	}
}
