// Padrão DTO
public class DadosCliente {
	public long? Cpf;
	public DateTime? DataNascimento;
	public int? Dependentes;
	public char? EstadoCivil;
	public string? Nome;
	public float? RendaMensal;

	public void Print() {
		Console.WriteLine($"Nome: {Nome}");
		Console.WriteLine($"CPF: {Cpf}");
		Console.WriteLine($"Data de nascimento: {DataNascimento}");
		Console.WriteLine($"Renda mensal: {RendaMensal}");
		Console.WriteLine($"Estado civil: {EstadoCivil}");
		Console.WriteLine($"Quantidade de dependentes: {Dependentes}");
	}
}
