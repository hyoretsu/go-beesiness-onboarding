public static class InteiroArmstrong {
	public static bool IsArmstrong(this int n) {
		IEnumerable<int> digitos = n.ToString().Select(digito => int.Parse(digito.ToString()));
		int digitosN = digitos.Count();

		double soma = 0;
		foreach (int digito in digitos) {
			soma += Math.Pow(digito, digitosN);
		}

		return soma == n;
	}
}
