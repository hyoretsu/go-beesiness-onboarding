using Domain.Modules.Appointments.Models;
using Domain.Modules.Patients.Models;

namespace Infra.Shared;

public static class Database {
	public static IEnumerable<Appointment> appointment = [];
	public static IEnumerable<Patient> patient = [];
}
