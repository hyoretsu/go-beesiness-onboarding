using Domain.Modules.Appointments.DTOs;
using Domain.Modules.Appointments.Models;
using Infra.Modules.Appointments.Controllers;

namespace Interface.Schedule;

public static class AppointmentList {
	public static void Run() {
		try {
			string choice;

			Console.Write("Apresentar a agenda T-Toda ou P-Periodo: ");
			choice = Console.ReadLine()!;
			if (choice != "T" && choice != "P") {
				throw new Exception("");
			}

			IEnumerable<Appointment> appointments;

			if (choice == "P") {
				DateTime startDate = DateTime.Now;
				DateTime endDate = DateTime.Now;

				appointments = AppointmentsController.List(new ListAppointmentsDTO {
					startDate = startDate,
					endDate = endDate
				});
			} else {
				appointments = AppointmentsController.List();
			}

			Console.WriteLine("-------------------------------------------------------------");
			Console.WriteLine("   Data    H.Ini H.Fim Tempo Nome                   Dt.Nasc. ");
			Console.WriteLine("-------------------------------------------------------------");

			foreach (IEnumerable<Appointment> dateAppointments in appointments.GroupBy(appointment => appointment.startTime.Date)) {
				for (int i = 0; i < dateAppointments.Count(); i++) {
					Appointment appointment = dateAppointments.ElementAt(i);
					var patient = appointment.Paciente!;

					if (i == 0) {
						Console.Write($"{appointment.startTime:dd/MM/yyyy} {appointment.startTime:HH:mm} ");
					} else {
						Console.Write($"{appointment.startTime,-11:HH:mm} ");
					}

					TimeSpan duration = appointment.endTime - appointment.startTime;

					Console.WriteLine($"{appointment.endTime:HH:mm} {duration.Hours.ToString().PadLeft(2, '0')}:{duration.Hours.ToString().PadRight(2, '0')} {patient.nome[..21]} {patient.birthDate:dd/MM/yyyy}");
				}
			}

			Console.WriteLine("-------------------------------------------------------------");
			Console.WriteLine("");
		} catch (Exception e) {
			Console.WriteLine(e.Message);
			Run();
		}
	}
}
