using OrdenacaoPartial.Projeto.Models;

namespace OrdenacaoPartial.Projeto.Algoritmos;

public static class QuickSortParcial
{
    public static int[] Executar(
        int[] vetor,
        int k,
        TipoBusca tipoBusca)
    {
        int[] copia = (int[])vetor.Clone();

        QuickSort(
            copia,
            0,
            copia.Length - 1,
            k,
            tipoBusca);

        int[] resultado = new int[k];

        Array.Copy(copia, resultado, k);

        return resultado;
    }

    private static void QuickSort(
        int[] vetor,
        int esq,
        int dir,
        int k,
        TipoBusca tipoBusca)
    {
        int i = esq;
        int j = dir;

        int pivo = vetor[(esq + dir) / 2];

        while (i <= j)
        {
            if (tipoBusca == TipoBusca.Menores)
            {
                while (vetor[i] < pivo)
                {
                    i++;
                }

                while (vetor[j] > pivo)
                {
                    j--;
                }
            }
            else
            {
                while (vetor[i] > pivo)
                {
                    i++;
                }

                while (vetor[j] < pivo)
                {
                    j--;
                }
            }

            if (i <= j)
            {
                int temp = vetor[i];
                vetor[i] = vetor[j];
                vetor[j] = temp;

                i++;
                j--;
            }
        }

        if (esq < j)
        {
            QuickSort(
                vetor,
                esq,
                j,
                k,
                tipoBusca);
        }

        if (i < k && i < dir)
        {
            QuickSort(
                vetor,
                i,
                dir,
                k,
                tipoBusca);
        }
    }
}