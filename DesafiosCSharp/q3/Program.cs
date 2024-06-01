// Triangulo equilatero = new Triangulo(new Vertice(0, 0), new Vertice(4, 0), new Vertice(2, 2));
Triangulo isosceles = new Triangulo(new Vertice(0, 0), new Vertice(2, 0), new Vertice(1, 2));
Triangulo escaleno = new Triangulo(new Vertice(0, 0), new Vertice(1, 0), new Vertice(1 / 2, Math.Sqrt(3) / 2));

Console.WriteLine(isosceles.perimetro);
Console.WriteLine(isosceles.area);
// Console.WriteLine(equilatero.tipo);
Console.WriteLine(isosceles.tipo);
Console.WriteLine(escaleno.tipo);
