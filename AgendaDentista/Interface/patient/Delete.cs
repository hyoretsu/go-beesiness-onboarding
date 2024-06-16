using System.Globalization;
using Domain.Modules.Patients.DTOs;
using Domain.Shared.Exceptions;
using Infra.Modules.Patients.Controllers;

namespace Interface.Patient;

public static class PatientDelete {
	public static void Run() {
		try {
			Console.Write("CPF: ");
			string cpf = Console.ReadLine()!;

			PatientsController.Delete(new DeletePatientDTO {
				cpf = cpf
			});

			Console.WriteLine("Paciente excluído com sucesso!");
		} catch (ApiException e) {
			Console.WriteLine(e.Message);
			Run();
		}
	}
}
