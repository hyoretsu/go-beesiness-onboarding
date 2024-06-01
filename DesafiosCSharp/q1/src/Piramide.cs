class Piramide {
	private int n;
	public int N {
		get => n;
		set {
			if (value < 1) {
				throw new Exception("'n' must be greater than zero.");
			}

			n = value;
		}
	}

	public Piramide(int n) {
		N = n;
	}

	public void Desenha() {
		for (int i = 1; i <= N; i++) {
			for (int k = i; k < N; k++) {
				Console.Write(" ");
			}

			for (int k = 1; k <= i; k++) {
				Console.Write(k);
			}
			if (i != 1) {
				for (int k = i - 1; k >= 1; k--) {
					Console.Write(k);
				}
			}

			for (int k = i; k < N; k++) {
				Console.Write(" ");
			}

			Console.WriteLine();
		}
	}
}
