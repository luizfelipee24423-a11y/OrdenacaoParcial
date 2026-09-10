namespace OrdenacaoPartial.Projeto.Utils;

public static class MedidorTempo
{
    public static T Executar<T>(
        Func<T> metodo)
    {
        DateTime inicio = DateTime.Now;

        Console.WriteLine(
            $"Início: {inicio:dd/MM/yyyy HH:mm:ss.fff}");

        T resultado = metodo();

        DateTime fim = DateTime.Now;

        Console.WriteLine(
            $"Fim: {fim:dd/MM/yyyy HH:mm:ss.fff}");

        Console.WriteLine(
            $"Duração: {(fim - inicio).TotalMilliseconds} ms");

        return resultado;
    }
}