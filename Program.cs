using OrdenacaoPartial.Projeto.Algoritmos;
using OrdenacaoPartial.Projeto.Models;
using OrdenacaoPartial.Projeto.Utils;

namespace OrdenacaoPartial;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== ORDENAÇÃO PARCIAL =====");

        int tamanhoVetor = LerTamanhoVetor();

        TipoVetor tipoVetor = LerTipoVetor();

        int k = LerQuantidadeK();

        TipoBusca tipoBusca = LerTipoBusca();

        TipoAlgoritmo algoritmo = LerAlgoritmo();

        int[] vetor =
            GeradorVetores.Gerar(tamanhoVetor, tipoVetor);

        Console.WriteLine("\nVetor Original:");

        Impressao.ExibirVetor(vetor);

        int[] resultado = algoritmo switch
        {
            TipoAlgoritmo.Selection =>
                SelectionSortParcial.Executar(vetor, k, tipoBusca),

            TipoAlgoritmo.Insertion =>
                InsertionSortParcial.Executar(vetor, k, tipoBusca),

            TipoAlgoritmo.Quick =>
                QuickSortParcial.Executar(vetor, k, tipoBusca),

            TipoAlgoritmo.Heap =>
                HeapSortParcial.Executar(vetor, k, tipoBusca),

            _ => throw new ArgumentException()
        };

        Console.WriteLine("\nResultado:");

        Impressao.ExibirVetor(resultado);
    }

    private static int LerTamanhoVetor()
    {
        Console.Write("Informe N: ");
        return int.Parse(Console.ReadLine()!);
    }

    private static int LerQuantidadeK()
    {
        Console.Write("Informe K: ");
        return int.Parse(Console.ReadLine()!);
    }

    private static TipoVetor LerTipoVetor()
    {
        Console.WriteLine("\nTipo do Vetor:");
        Console.WriteLine("1 - Crescente");
        Console.WriteLine("2 - Decrescente");
        Console.WriteLine("3 - Aleatório");

        return (TipoVetor)int.Parse(Console.ReadLine()!);
    }

    private static TipoBusca LerTipoBusca()
    {
        Console.WriteLine("\nBusca:");

        Console.WriteLine("1 - Menores elementos");
        Console.WriteLine("2 - Maiores elementos");

        return (TipoBusca)int.Parse(Console.ReadLine()!);
    }

    private static TipoAlgoritmo LerAlgoritmo()
    {
        Console.WriteLine("\nAlgoritmo:");

        Console.WriteLine("1 - Selection Parcial");
        Console.WriteLine("2 - Insertion Parcial");
        Console.WriteLine("3 - Quick Parcial");
        Console.WriteLine("4 - Heap Parcial");

        return (TipoAlgoritmo)
            int.Parse(Console.ReadLine()!);
    }
}