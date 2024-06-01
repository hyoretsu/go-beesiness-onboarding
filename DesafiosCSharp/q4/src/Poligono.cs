public class Poligono {
	private List<Vertice> vertices;
	public int NumVertices {
		get => vertices.Count;
	}

	public Poligono(Vertice[] vertices) {
		if (vertices.Length < 3) {
			throw new Exception("A quantidade de vértices fornecida não forma um polígono.");
		}

		this.vertices = [.. vertices];
	}

	public double Perimetro() {
		double perimetro = 0;

		for (int i = 0; i < vertices.Count - 1; i++) {
			perimetro += vertices[i].Distancia(vertices[i + 1]);
		}

		perimetro += vertices.Last().Distancia(vertices[0]);

		return perimetro;
	}

	public bool AddVertice(Vertice v) {
		foreach (Vertice vertice in vertices) {
			if (vertice.Equals(v)) {
				return false;
			}
		}

		vertices.Add(v);

		return true;
	}

	public void RemoveVertice(Vertice v) {
		if (vertices.Count == 3) {
			throw new Exception("Não é possível remover um vértice de um polígono com 3 vértices.");
		}

		vertices.RemoveAt(vertices.FindIndex(vertice => vertice.Equals(v)));
	}
}
