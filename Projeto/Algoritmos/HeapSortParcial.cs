using OrdenacaoPartial.Projeto.Models;

namespace OrdenacaoPartial.Projeto.Algoritmos;

public static class HeapSortParcial
{
    public static int[] Executar(
        int[] vetor,
        int k,
        TipoBusca tipoBusca)
    {
        int[] copia = (int[])vetor.Clone();

        // Constrói o heap somente com os K primeiros elementos
        for (int i = k / 2 - 1; i >= 0; i--)
        {
            Heapify(copia, k, i, tipoBusca);
        }

        // Analisa os elementos restantes do vetor
        for (int i = k; i < copia.Length; i++)
        {
            bool deveEntrar;

            if (tipoBusca == TipoBusca.Menores)
            {
                deveEntrar = copia[i] < copia[0];
            }
            else
            {
                deveEntrar = copia[i] > copia[0];
            }

            if (deveEntrar)
            {
                copia[0] = copia[i];

                Heapify(
                    copia,
                    k,
                    0,
                    tipoBusca);
            }
        }

        // Ordena somente os K elementos selecionados
        for (int fim = k - 1; fim > 0; fim--)
        {
            int temp = copia[0];
            copia[0] = copia[fim];
            copia[fim] = temp;

            Heapify(
                copia,
                fim,
                0,
                tipoBusca);
        }

        int[] resultado = new int[k];

        Array.Copy(copia, resultado, k);

        return resultado;
    }

    private static void Heapify(
        int[] vetor,
        int tamanhoHeap,
        int raiz,
        TipoBusca tipoBusca)
    {
        int escolhido = raiz;

        int esquerdo = 2 * raiz + 1;
        int direito = 2 * raiz + 2;

        if (
            esquerdo < tamanhoHeap &&
            TemPrioridade(
                vetor[esquerdo],
                vetor[escolhido],
                tipoBusca)
        )
        {
            escolhido = esquerdo;
        }

        if (
            direito < tamanhoHeap &&
            TemPrioridade(
                vetor[direito],
                vetor[escolhido],
                tipoBusca)
        )
        {
            escolhido = direito;
        }

        if (escolhido != raiz)
        {
            int temp = vetor[raiz];
            vetor[raiz] = vetor[escolhido];
            vetor[escolhido] = temp;

            Heapify(
                vetor,
                tamanhoHeap,
                escolhido,
                tipoBusca);
        }
    }

    private static bool TemPrioridade(
        int primeiro,
        int segundo,
        TipoBusca tipoBusca)
    {
        if (tipoBusca == TipoBusca.Menores)
        {
            return primeiro > segundo;
        }

        return primeiro < segundo;
    }
}