using Infra.Modules.Appointments.Repository;
using Infra.Modules.Patients.Repository;

namespace Infra.Shared;

public static class SingletonClasses {
	// I'm not using their interfaces because of database access
	public static readonly MemoryAppointmentsRepository appointmentsRepository = new();
	public static readonly MemoryPatientsRepository patientsRepository = new();
}
