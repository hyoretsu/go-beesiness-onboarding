public class Motor {
	public readonly double cilindrada;
	// Como não pensei numa maneira decente de bloquear a remoção do motor de um carro que não seja a partir da classe Carro, não faz mal deixar público.
	public Carro? carro;

	public Motor(double cilindrada) {
		this.cilindrada = cilindrada;
	}
}
