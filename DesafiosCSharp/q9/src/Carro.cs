public class Carro {
	public readonly string Placa;
	public readonly string Modelo;
	private Motor? motor;
	public Motor Motor {
		get => motor!;
		set {
			if (value.carro != null) {
				throw new Exception("Não é possível colocar um mesmo motor em dois carros diferentes.");
			}
			if (motor != null) {
				motor.carro = null;
			}
			motor = value;
			motor.carro = this;
		}
	}

	public Carro(string placa, string modelo, Motor motor) {
		Placa = placa;
		Modelo = modelo;
		Motor = motor;
	}

	public int VelocidadeMaxima() {
		if (Motor.cilindrada <= 1.0) {
			return 140;
		} else if (Motor.cilindrada <= 1.6) {
			return 160;
		} else if (Motor.cilindrada <= 2.0) {
			return 180;
		} else {
			return 220;
		}
	}
}
