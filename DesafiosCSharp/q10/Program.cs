List<int> ints = [1, 2, 3, 4, 5, 5];
Console.WriteLine($"Antes {ints.Count}");
ints.RemoveRepetidos();
Console.WriteLine($"Depois {ints.Count}");

List<Cliente> clientes = [new Cliente("Aran", "cpf"), new Cliente("Aran2", "cpf")];
Console.WriteLine($"Antes {clientes.Count}");
clientes.RemoveRepetidos();
Console.WriteLine($"Depois {clientes.Count}");

public class Cliente : IEquatable<Cliente> {
	public string Nome;
	public string Cpf;

	public Cliente(string nome, string cpf) {
		Nome = nome;
		Cpf = cpf;
	}

	public bool Equals(Cliente? other) {
		return other != null && Cpf == other.Cpf;
	}

	// Necessário, ambos LINQ e HashSet usam ele
	public override int GetHashCode() {
		return Cpf.GetHashCode();
	}
}
