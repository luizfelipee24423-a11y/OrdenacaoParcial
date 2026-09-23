using OrdenacaoPartial.Projeto.Models;

namespace OrdenacaoPartial.Projeto.Algoritmos;

public static class InsertionSortParcial
{
    public static int[] Executar(
        int[] vetor,
        int k,
        TipoBusca tipoBusca)
    {
        int[] copia = (int[])vetor.Clone();

        for (int i = 1; i < copia.Length; i++)
        {
            int tmp = copia[i];

            int j = (i < k) ? i - 1 : k - 1;

            if (tipoBusca == TipoBusca.Menores)
            {
                while (j >= 0 && copia[j] > tmp)
                {
                    copia[j + 1] = copia[j];
                    j--;
                }
            }
            else
            {
                while (j >= 0 && copia[j] < tmp)
                {
                    copia[j + 1] = copia[j];
                    j--;
                }
            }

            copia[j + 1] = tmp;
        }

        int[] resultado = new int[k];

        Array.Copy(copia, resultado, k);

        return resultado;
    }
}