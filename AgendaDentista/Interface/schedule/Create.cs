using System.Globalization;
using Domain.Modules.Appointments.DTOs;
using Infra.Modules.Appointments.Controllers;

namespace Interface.Schedule;

public static class AppointmentCreate {
	public static void Run() {
		string cpf, dateStr, endTimeStr, name, startTimeStr;

		try {
			Console.Write("CPF: ");
			cpf = Console.ReadLine()!;

			Console.Write("Data da consulta: ");
			dateStr = Console.ReadLine()!;

			string[] dateComponents = dateStr.Split('/');

			if (dateComponents[0].Length != 2 || dateComponents[1].Length != 2 || dateComponents[2].Length != 4) {
				throw new Exception("A data de nascimento deve estar no formato DD/MM/AAAA.");
			}

			DateTime date;
			if (!DateTime.TryParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
				throw new Exception("A data de nascimento fornecida é inválida.");
			}

			Console.Write("Hora inicial: ");
			startTimeStr = Console.ReadLine()!;

			// Todo: validação de minutagem está generalista
			int startHour = int.Parse(startTimeStr[..2]);
			if (startHour < 8 || startHour >= 19) {
				throw new Exception("A hora inicial deve estar entre 08:00 e 19:00.");
			}
			int startMinute = int.Parse(startTimeStr[2..]);
			if (startMinute < 0 || startMinute >= 60 || startMinute % 15 != 0) {
				throw new Exception("Minutos iniciais inválidos.");
			}

			DateTime startTime = date.AddHours(startHour).AddMinutes(startMinute);

			Console.Write("Hora final: ");
			endTimeStr = Console.ReadLine()!;

			int endHour = int.Parse(endTimeStr[..2]);
			if (endHour < 8 || endHour >= 19) {
				throw new Exception("A hora inicial deve estar entre 08:00 e 19:00.");
			}
			int endMinute = int.Parse(endTimeStr[2..]);
			if (endMinute < 15 || endMinute >= 60 || endMinute % 15 != 0) {
				throw new Exception("Minutos iniciais inválidos.");
			}

			DateTime endTime = date.AddHours(endHour).AddMinutes(endMinute);

			AppointmentsController.Create(new CreateAppointmentDTO {
				cpf = cpf,
				endTime = endTime,
				startTime = startTime,
			});

			Console.WriteLine("Agendamento realizado com sucesso!");
		} catch (Exception e) {
			// Todo: ask again for wrong inputs
			Console.WriteLine(e.Message);
		}
	}
}
