using Interface.Patient;

namespace Interface;

public static class MainMenu {
	public static void Run() {
		int option;
		do {
			Console.WriteLine("Menu Principal");
			Console.WriteLine("1-Cadastro de pacientes");
			Console.WriteLine("2-Agenda");
			Console.WriteLine("3-Fim");

			option = (int)char.GetNumericValue(Console.ReadLine()!.ToCharArray()[0]);
			switch (option) {
				case 1:
					PatientMenu.Run();
					break;
				case 2:
					break;
				case 3:
					break;
				default:
					Console.WriteLine("Opção inválida");
					break;
			}

			Console.WriteLine("");
		} while (option != 3);
	}
}
