public class ListaIntervalo {
	private List<Intervalo> intervalos;
	public Intervalo[] Intervalos {
		get => [.. intervalos];
	}

	public ListaIntervalo(Intervalo[] intervalos) {
		this.intervalos = [.. intervalos];
		this.intervalos.Sort();
	}

	public void Add(Intervalo i) {
		foreach (Intervalo intervalo in intervalos) {
			if (intervalo.TemIntersecao(i)) {
				throw new Exception("Inserção inválida.");
			}
		}

		intervalos = [.. intervalos.Append(i)];
		intervalos.Sort();
	}
}
