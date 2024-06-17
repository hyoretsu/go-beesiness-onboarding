using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Appointments.Repository;

namespace Domain.Modules.Appointments.Services;

public class ListAppointmentsService(IAppointmentsRepository appointmentsRepository) {
	private readonly IAppointmentsRepository appointmentsRepository = appointmentsRepository;

	public IEnumerable<Appointment> Execute(ListAppointmentsDTO? data) {
		IEnumerable<Appointment> appointments;

		if (data != null) {
			appointments = appointmentsRepository.FindByPeriod(data.startDate, data.endDate);
		} else {
			appointments = appointmentsRepository.FindAll();
		}

		return appointments;
	}
}
