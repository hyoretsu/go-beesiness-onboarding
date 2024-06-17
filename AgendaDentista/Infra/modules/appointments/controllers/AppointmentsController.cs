using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Appointments.Services;
using Infra.Shared;

namespace Infra.Modules.Appointments.Controllers;

public static class AppointmentsController {
	private static readonly CreateAppointmentService createAppointment = new(SingletonClasses.appointmentsRepository, SingletonClasses.patientsRepository);
	private static readonly DeleteAppointmentService deleteAppointment = new(SingletonClasses.appointmentsRepository, SingletonClasses.patientsRepository);
	private static readonly ListAppointmentsService listAppointments = new(SingletonClasses.appointmentsRepository);

	public static Appointment Create(CreateAppointmentDTO data) {
		Appointment appointment = createAppointment.Execute(data);

		return appointment;
	}

	public static void Delete(DeleteAppointmentDTO data) {
		deleteAppointment.Execute(data);
	}

	public static IEnumerable<Appointment> List() {
		IEnumerable<Appointment> appointments = listAppointments.Execute(null);

		return appointments;
	}

	public static IEnumerable<Appointment> List(ListAppointmentsDTO data) {
		IEnumerable<Appointment> appointments = listAppointments.Execute(data);

		return appointments;
	}
}
