using Domain.Modules.Patients.Models;
using Infra.Modules.Patients.Controllers;

public class PatientListByCpf {
	public static void Run() {
		IEnumerable<Patient> patients = PatientsController.ListByCpf();

		Console.WriteLine("------------------------------------------------------------");
		Console.WriteLine("CPF         Nome                              Dt.Nasc. Idade");
		Console.WriteLine("------------------------------------------------------------");

		foreach (Patient patient in patients) {
			Console.WriteLine($"{patient.cpf} {patient.nome,-32} {patient.birthDate:dd/MM/yyyy} {Utils.GetAge(patient.birthDate),4}");
		}

		Console.WriteLine("------------------------------------------------------------");
	}
}
