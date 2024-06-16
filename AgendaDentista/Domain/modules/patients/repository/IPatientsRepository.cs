using Domain.Modules.Patients.DTOs;
using Domain.Modules.Patients.Models;

namespace Domain.Modules.Patients.Repository;

public interface IPatientsRepository {
	public Patient Create(CreatePatientDTO data);
	public void Delete(string cpf);
	public Patient[] FindAll();
	public Patient? FindByCpf(string cpf);
}
