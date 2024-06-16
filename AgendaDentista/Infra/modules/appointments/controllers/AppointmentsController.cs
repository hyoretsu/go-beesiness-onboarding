using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Appointments.Repository;
using Domain.Modules.Appointments.Services;
using Infra.Modules.Appointments.Repository;
using Infra.Shared;

namespace Infra.Modules.Appointments.Controllers;

public static class AppointmentsController {
	public static readonly CreateAppointmentService createAppointment = new(SingletonClasses.appointmentsRepository, SingletonClasses.patientsRepository);

	public static Appointment Create(CreateAppointmentDTO data) {
		Appointment appointment = createAppointment.Execute(data);

		return appointment;
	}
}
