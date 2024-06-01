Poligono poligono = new Poligono([new Vertice(0, 0), new Vertice(2, 0), new Vertice(1, 2)]);

Console.WriteLine(poligono.NumVertices);
Console.WriteLine(poligono.Perimetro());
poligono.AddVertice(new Vertice(5, 5));
Console.WriteLine(poligono.NumVertices);
Console.WriteLine(poligono.Perimetro());
poligono.RemoveVertice(new Vertice(5, 5));
Console.WriteLine(poligono.NumVertices);
Console.WriteLine(poligono.Perimetro());
