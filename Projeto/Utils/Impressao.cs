namespace OrdenacaoPartial.Projeto.Utils;

public static class Impressao
{
    public static void ExibirVetor(
        int[] vetor)
    {
        Console.WriteLine(
            string.Join(", ", vetor));
    }
}
