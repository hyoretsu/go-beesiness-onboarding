namespace Interface.Patient;

public static class PatientMenu {
	public static void Run() {
		int option;

		do {
			Console.WriteLine("Menu do Cadastro de Pacientes");
			Console.WriteLine("1-Cadastrar novo paciente");
			Console.WriteLine("2-Excluir paciente");
			Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
			Console.WriteLine("4-Listar pacientes (ordenado por nome)");
			Console.WriteLine("5-Voltar p/ menu principal");

			option = (int)char.GetNumericValue(Console.ReadLine()!.ToCharArray()[0]);

			switch (option) {
				case 1:
					PatientRegister.Run();
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					PatientListByName.Run();
					break;
				case 5:
					break;
				default:
					Console.WriteLine("Opção inválida");
					break;
			}

			Console.WriteLine("");
		} while (option != 5);
	}
}
