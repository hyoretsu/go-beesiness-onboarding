using System.Text.RegularExpressions;
using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;
using Domain.Modules.Patients.Repository;
using Domain.Shared.Exceptions;

namespace Domain.Modules.Patients.Services;

public class CreatePatientService(IPatientsRepository patientsRepository) {
	private readonly IPatientsRepository patientsRepository = patientsRepository;

	public Patient Execute(CreatePatientDTO data) {
		if (data.nome.Length < 5) {
			throw new ApiException("O nome deve conter pelo menos 5 caracteres.", "nome");
		}

		int age = Utils.GetAge(data.birthDate);
		if (age < 13) {
			throw new ApiException("O dentista não atende crianças.", "birthDate");
		}

		if (!Regex.IsMatch(data.cpf, "\\d{11}")) {
			throw new ApiException("O CPF fornecido não tem 11 dígitos.", "cpf");
		}

		if (!Utils.ValidCpf(data.cpf)) {
			throw new ApiException("O CPF fornecido é inválido.", "cpf");
		}

		Patient? existingPatient = patientsRepository.FindByCpf(data.cpf);
		if (existingPatient != null) {
			throw new Exception();
		}

		Patient patient = patientsRepository.Create(new CreatePatientDTO {
			birthDate = data.birthDate,
			cpf = data.cpf,
			nome = data.nome
		});

		return patient;
	}
}
