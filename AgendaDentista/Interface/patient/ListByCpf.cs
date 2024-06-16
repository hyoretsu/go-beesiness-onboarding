using Domain.Modules.Appointments.Models;
using Domain.Modules.Patients.Models;
using Infra.Modules.Patients.Controllers;

public class PatientListByCpf {
	public static void Run() {
		IEnumerable<Patient> patients = PatientsController.ListByCpf();

		Console.WriteLine("------------------------------------------------------------");
		Console.WriteLine("CPF         Nome                              Dt.Nasc. Idade");
		Console.WriteLine("------------------------------------------------------------");

		foreach (Patient patient in patients) {
			Appointment appointment = patient.Agendamentos.First();

			Console.WriteLine($"{patient.cpf} {patient.nome,-32} {patient.birthDate:dd/MM/yyyy} {Utils.GetAge(patient.birthDate),4}");
			if (appointment != null) {
				Console.WriteLine($"{"Agendado para:",12} {appointment.startTime:dd/MM/yyyy}");
				Console.WriteLine($"{appointment.startTime,12:HH:mm} às {appointment.endTime:HH:mm}");
			}
		}

		Console.WriteLine("------------------------------------------------------------");
	}
}
