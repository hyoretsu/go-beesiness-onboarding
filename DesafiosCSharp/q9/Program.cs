Motor motor1 = new Motor(1.0);
Motor motor2 = new Motor(1.6);
Motor motor3 = new Motor(2.0);

Carro carro1 = new Carro("ABC", "A", motor1);
// Carro carro2 = new Carro("DEF", "B", motor1); // Exceção
Carro carro2 = new Carro("DEF", "B", motor2);
// Essa troca e a exceção acima confirma que há uma exclusão mútua no controle dos motores, que é um dos requisitos.
carro1.Motor = motor3;
carro2.Motor = motor1;

Console.WriteLine(carro1.VelocidadeMaxima());
