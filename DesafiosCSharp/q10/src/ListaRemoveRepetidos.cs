using System.Collections;

public static class ListaRemoveRepetidos {
	public static void RemoveRepetidos<T>(this List<T> lista) {
		// Runtime check to ensure T implements IEquatable<T>
		if (!typeof(IEquatable<T>).IsAssignableFrom(typeof(T))) {
			throw new InvalidOperationException($"The type {typeof(T).FullName} must implement IEquatable<{typeof(T).FullName}>.");
		}

		// Sem o .ToList() ele não carrega tudo na memória e some com o .Clear()
		List<T> itensUnicos = lista.Distinct().ToList();
		lista.Clear();
		lista.AddRange(itensUnicos);
	}
}
