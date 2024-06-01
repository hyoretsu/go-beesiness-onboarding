public class Intervalo {
	public readonly DateTime startTime;
	public readonly DateTime endTime;
	public readonly TimeSpan duracao;

	public Intervalo(DateTime startTime, DateTime endTime) {
		if (startTime.CompareTo(endTime) > 0) {
			throw new Exception("O início do intervalo não pode ser maior que o final.");
		}

		this.startTime = startTime;
		this.endTime = endTime;
		duracao = endTime.Subtract(startTime);
	}

	public bool Equals(Intervalo intervalo) {
		return startTime.Equals(intervalo.startTime) && endTime.Equals(intervalo.endTime);
	}

	public bool TemIntersecao(Intervalo intervalo) {
		// Engenhosidade GPT
		return startTime.CompareTo(intervalo.endTime) <= 0 && intervalo.startTime.CompareTo(endTime) <= 0;
	}
}
