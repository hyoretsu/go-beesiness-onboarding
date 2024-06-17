using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Appointments.Repository;
using Infra.Shared;

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

	public IEnumerable<Appointment> FindAll() {
		IEnumerable<Appointment> appointments = Appointments;
		foreach (Appointment appointment in appointments) {
			appointment.Paciente = SingletonClasses.patientsRepository.Patients.Where(patient => patient.cpf == appointment.patientCpf).First();
		}

		return appointments;
	}

	public IEnumerable<Appointment> FindByCpf(string cpf) {
		IEnumerable<Appointment> appointments = Appointments.Where(appointment => appointment.patientCpf == cpf);

		return appointments;
	}

	public IEnumerable<Appointment> FindByPeriod(DateTime startDate, DateTime endDate) {
		IEnumerable<Appointment> appointments = Appointments.Where(appointment => appointment.startTime >= startDate && appointment.endTime <= endDate);
		foreach (Appointment appointment in appointments) {
			appointment.Paciente = SingletonClasses.patientsRepository.Patients.Where(patient => patient.cpf == appointment.patientCpf).First();
		}

		return appointments;
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
