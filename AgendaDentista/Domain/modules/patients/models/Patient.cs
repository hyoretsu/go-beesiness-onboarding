using System.Collections;
using Domain.Modules.Appointments.Models;
using Domain.Modules.Patients.DTOs;

namespace Domain.Modules.Patients.Models;

public class Patient {
	public readonly DateTime birthDate;
	public readonly string cpf;
	public readonly string nome;
	public IEnumerable<Appointment> Agendamentos = [];
	public readonly DateTime createdAt;
	public readonly DateTime updatedAt;

	public Patient(CreatePatientDTO data) {
		birthDate = data.birthDate;
		cpf = data.cpf;
		nome = data.nome;
		createdAt = DateTime.Now;
		updatedAt = createdAt;
	}

	public class CpfComparer : IComparer {
		int IComparer.Compare(object? x, object? y) {
			return Int32.Parse((x as Patient)?.cpf!).CompareTo(Int32.Parse((y as Patient)?.cpf!))!;
		}
	}

	public class NameComparer : IComparer {
		int IComparer.Compare(object? x, object? y) {
			return (int)(x as Patient)?.nome.CompareTo((y as Patient)?.nome)!;
		}
	}
}
