namespace Interface.Schedule;

public static class ScheduleMenu {
	public static void Run() {
		int option;

		do {
			Console.WriteLine("Menu do Cadastro de Pacientes");
			Console.WriteLine("1-Agendar consulta");
			Console.WriteLine("2-Cancelar agendamento");
			Console.WriteLine("3-Listar agenda");
			Console.WriteLine("4-Voltar p/ menu principal");

			option = (int)char.GetNumericValue(Console.ReadLine()!.ToCharArray()[0]);

			switch (option) {
				case 1:
					AppointmentCreate.Run();
					break;
				case 2:
					break;
				case 3:
					AppointmentList.Run();
					break;
				case 4:
					break;
				default:
					Console.WriteLine("Opção inválida");
					break;
			}

			Console.WriteLine("");
		} while (option != 4);
	}
}
