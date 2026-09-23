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

        int k = LerQuantidadeK(tamanhoVetor);

        TipoBusca tipoBusca = LerTipoBusca();

        TipoAlgoritmo algoritmo = LerAlgoritmo();

        int[] vetor =
            GeradorVetores.Gerar(tamanhoVetor, tipoVetor);

        Console.WriteLine("\nVetor Original:");

        Impressao.ExibirVetor(vetor);

        Console.WriteLine("\nExecutando algoritmo...");

        int[] resultado =
            MedidorTempo.Executar(
                () => ExecutarAlgoritmo(
                    algoritmo,
                    vetor,
                    k,
                    tipoBusca));

        Console.WriteLine("\nResultado:");

        Impressao.ExibirVetor(resultado);
    }

    private static int[] ExecutarAlgoritmo(
        TipoAlgoritmo algoritmo,
        int[] vetor,
        int k,
        TipoBusca tipoBusca)
    {
        return algoritmo switch
        {
            TipoAlgoritmo.Selection =>
                SelectionSortParcial.Executar(
                    vetor,
                    k,
                    tipoBusca),

            TipoAlgoritmo.Insertion =>
                InsertionSortParcial.Executar(
                    vetor,
                    k,
                    tipoBusca),

            TipoAlgoritmo.Quick =>
                QuickSortParcial.Executar(
                    vetor,
                    k,
                    tipoBusca),

            TipoAlgoritmo.Heap =>
                HeapSortParcial.Executar(
                    vetor,
                    k,
                    tipoBusca),

            _ => throw new ArgumentException(
                "Algoritmo inválido.")
        };
    }

    private static int LerTamanhoVetor()
    {
        while (true)
        {
            Console.Write("Informe N: ");

            if (
                int.TryParse(
                    Console.ReadLine(),
                    out int n)
                &&
                n > 0
            )
            {
                return n;
            }

            Console.WriteLine(
                "Valor inválido. N deve ser maior que zero.");
        }
    }

    private static int LerQuantidadeK(
        int tamanhoVetor)
    {
        while (true)
        {
            Console.Write("Informe K: ");

            if (
                int.TryParse(
                    Console.ReadLine(),
                    out int k)
                &&
                k > 0
                &&
                k <= tamanhoVetor
            )
            {
                return k;
            }

            Console.WriteLine(
                $"Valor inválido. K deve estar entre 1 e {tamanhoVetor}.");
        }
    }

    private static TipoVetor LerTipoVetor()
    {
        while (true)
        {
            Console.WriteLine("\nTipo do Vetor:");
            Console.WriteLine("1 - Crescente");
            Console.WriteLine("2 - Decrescente");
            Console.WriteLine("3 - Aleatório");

            if (
                int.TryParse(
                    Console.ReadLine(),
                    out int opcao)
                &&
                opcao >= 1
                &&
                opcao <= 3
            )
            {
                return (TipoVetor)opcao;
            }

            Console.WriteLine(
                "Opção inválida.");
        }
    }

    private static TipoBusca LerTipoBusca()
    {
        while (true)
        {
            Console.WriteLine("\nBusca:");
            Console.WriteLine("1 - Menores elementos");
            Console.WriteLine("2 - Maiores elementos");

            if (
                int.TryParse(
                    Console.ReadLine(),
                    out int opcao)
                &&
                opcao >= 1
                &&
                opcao <= 2
            )
            {
                return (TipoBusca)opcao;
            }

            Console.WriteLine(
                "Opção inválida.");
        }
    }

    private static TipoAlgoritmo LerAlgoritmo()
    {
        while (true)
        {
            Console.WriteLine("\nAlgoritmo:");
            Console.WriteLine("1 - Selection Parcial");
            Console.WriteLine("2 - Insertion Parcial");
            Console.WriteLine("3 - Quick Parcial");
            Console.WriteLine("4 - Heap Parcial");

            if (
                int.TryParse(
                    Console.ReadLine(),
                    out int opcao)
                &&
                opcao >= 1
                &&
                opcao <= 4
            )
            {
                return (TipoAlgoritmo)opcao;
            }

            Console.WriteLine(
                "Opção inválida.");
        }
    }
}