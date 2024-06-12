public class ListaIntervalo {
	public List<Intervalo> Intervalos {
		get;
		private set;
	}

	public ListaIntervalo(Intervalo[] intervalos) {
		Intervalos = [.. intervalos];
		Intervalos.Sort();
	}

	public void Add(Intervalo i) {
		foreach (Intervalo intervalo in Intervalos) {
			if (intervalo.TemIntersecao(i)) {
				throw new Exception("Inserção inválida.");
			}
		}

		Intervalos = [.. Intervalos.Append(i)];
		Intervalos.Sort();
	}
}
