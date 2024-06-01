public class Vertice(double x, double y) {
	private double x = x;
	private double y = y;

	public double X {
		get => x;
	}
	public double Y {
		get => y;
	}

	public double Distancia(Vertice vertice) {
		return Math.Sqrt(Math.Pow(x - vertice.X, 2) + Math.Pow(y - vertice.Y, 2));
	}

	public void Move(float x, float y) {
		this.x = x;
		this.y = y;
	}

	public bool Equals(Vertice vertice) {
		return x == vertice.X && y == vertice.Y;
	}
}
