using Domain.Modules.Appointments.Repository;
using Domain.Modules.Patients.Repository;
using Infra.Modules.Appointments.Repository;
using Infra.Modules.Patients.Repository;

namespace Infra.Shared;

public static class SingletonClasses {
	public static readonly IAppointmentsRepository appointmentsRepository = new MemoryAppointmentsRepository();
	public static readonly IPatientsRepository patientsRepository = new MemoryPatientsRepository();
}
