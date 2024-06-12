using System.Globalization;
using Domain.Modules.Patients.DTOs;
using Domain.Shared.Exceptions;
using Infra.Modules.Patients;

namespace Interface.Patient;

public static class PatientRegister {
	public static void Run() {
		string birthDateStr, cpf, name;

		try {
			Console.Write("CPF: ");
			cpf = Console.ReadLine()!;
			Console.Write("Nome: ");
			name = Console.ReadLine()!;
			Console.Write("Data de nascimento: ");
			birthDateStr = Console.ReadLine()!;

			if (birthDateStr.Split('/').Length != 3) {
				throw new ApiException("A data de nascimento deve estar no formato DD/MM/AAAA.", "birthDate");
			}

			DateTime birthDate;
			if (!DateTime.TryParseExact(birthDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate)) {
				throw new ApiException("A data de nascimento fornecida é inválida.", "birthDate");
			}

			PatientsController.Create(new CreatePatientDTO {
				birthDate = birthDate,
				cpf = cpf,
				nome = name,
			});

			Console.WriteLine("Paciente cadastrado com sucesso!");
		} catch (ApiException e) {
			// Todo: ask again for wrong inputs
			Console.WriteLine(e.Message);
		}
	}
}
