public enum TipoTriangulo {
	Equilatero,
	Isosceles,
	Escaleno
}

public class Triangulo {
	private Vertice v1;
	private Vertice v2;
	private Vertice v3;
	private double[] lados;
	public readonly double perimetro;
	public readonly TipoTriangulo tipo;
	public readonly double area;

	public Vertice V1 {
		get => v1;
	}
	public Vertice V2 {
		get => v2;
	}
	public Vertice V3 {
		get => v3;
	}


	public Triangulo(Vertice v1, Vertice v2, Vertice v3) {
		lados = [v1.Distancia(v2), v1.Distancia(v3), v2.Distancia(v3)];

		if ((lados[0] + lados[1] >= lados[2]) || (lados[0] + lados[2] >= lados[1]) || (lados[1] + lados[2] >= lados[0])) {
			throw new Exception("Os lados recebidos não formam um triângulo.");
		}

		// foreach (double lado in lados) {
		// 	Console.WriteLine(lado);
		// }

		if (lados[0] == lados[1]) {
			if (lados[0] == lados[2]) {
				tipo = TipoTriangulo.Equilatero;
			} else {
				tipo = TipoTriangulo.Isosceles;
			}
		} else if (lados[1] == lados[2]) {
			tipo = TipoTriangulo.Isosceles;
		} else {
			tipo = TipoTriangulo.Escaleno;
		}

		this.v1 = v1;
		this.v2 = v2;
		this.v3 = v3;
		perimetro = lados[0] + lados[1] + lados[2];

		double S = perimetro / 2;
		area = Math.Sqrt(S * (S - lados[0]) * (S - lados[1]) * (S - lados[2]));
	}
}
