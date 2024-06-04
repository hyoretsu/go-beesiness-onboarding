using System.Text.RegularExpressions;

public class Formulario {
	public readonly DadosCliente dados;

	public Formulario() {
		dados = new DadosCliente();
	}

	public void begin() {
		while (dados.Nome == null) {
			pedirNome();
		}
		while (dados.Cpf == null) {
			pedirCpf();
		}
		while (dados.DataNascimento == null) {
			pedirDataDeNascimento();
		}
		while (dados.RendaMensal == null) {
			pedirRendaMensal();
		}
		while (dados.Dependentes == null) {
			pedirDependentes();
		}
		while (dados.EstadoCivil == null) {
			pedirEstadoCivil();
		}
	}

	private void pedirCpf() {
		Console.WriteLine("Digite seu CPF:");
		string cpf = Console.ReadLine()!;

		if (cpf.Length != 11) {
			Console.WriteLine("Um CPF válido deve conter exatamente 11 dígitos, tente novamente.");
			return;
		}

		dados.Cpf = long.Parse(cpf);
	}

	private void pedirDataDeNascimento() {
		Console.WriteLine("Digite sua data de nascimento:");
		string dataNascimento = Console.ReadLine()!;
		if (!Regex.IsMatch(dataNascimento, "\\d\\d\\/\\d\\d\\/\\d\\d\\d\\d")) {
			Console.WriteLine("Uma data válida deve estar no formato DD/MM/AAAA, tente novamente.");
			return;
		}

		DateTime data = DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", null);

		// https://stackoverflow.com/a/4127396
		int idade = (new DateTime(1, 1, 1) + (DateTime.Now - data)).Year - 1;
		if (idade < 18) {
			Console.WriteLine("Você deve ter pelo menos 18 anos, tente novamente.");
			return;
		}

		dados.DataNascimento = data;
	}

	private void pedirDependentes() {
		Console.WriteLine("Digite a quantidade de dependentes:");
		try {
			int dependentes = int.Parse(Console.ReadLine()!);

			if (dependentes < 0 || dependentes > 10) {
				Console.WriteLine("A quantidade de dependentes deve estar entre 0 e 10, tente novamente.");
				return;
			}

			dados.Dependentes = dependentes;
		} catch {
			Console.WriteLine("A quantidade de dependentes deve ser um número, tente novamente.");
			return;
		}
	}

	private void pedirEstadoCivil() {
		Console.WriteLine("Digite seu estado civil:");
		string estadoCivil = Console.ReadLine()!.ToUpper();

		if (estadoCivil.Length != 1 || (estadoCivil != "C" && estadoCivil != "S" && estadoCivil != "V" && estadoCivil != "D")) {
			Console.WriteLine("Um estado civil válido deve ser 'C', 'S', 'V' ou 'D', tente novamente.");
			return;
		}

		dados.EstadoCivil = estadoCivil[0];
	}

	private void pedirNome() {
		Console.WriteLine("Digite seu nome:");
		string nome = Console.ReadLine()!;

		if (nome.Length < 5) {
			Console.WriteLine("O nome deve conter pelo menos 5 caracteres, tente novamente.");
			return;
		}

		dados.Nome = nome;
	}

	private void pedirRendaMensal() {
		Console.WriteLine("Digite sua renda mensal:");
		// Assumindo que "lida com duas casas decimais e vírgula decimal" quer dizer que o input seguira esse padrão
		float rendaMensal = float.Parse(Console.ReadLine()!.Replace(".", "").Replace(",", "."));
		if (rendaMensal < 0) {
			Console.WriteLine("A renda mensal deve ser um número positivo, tente novamente.");
			return;
		}

		dados.RendaMensal = rendaMensal;
	}
}
