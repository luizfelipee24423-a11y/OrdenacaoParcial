using OrdenacaoPartial.Projeto.Models;

namespace OrdenacaoPartial.Projeto.Algoritmos;

public static class SelectionSortParcial
{
    public static int[] Executar(
        int[] vetor,
        int k,
        TipoBusca tipoBusca)
    {
        int[] copia = (int[])vetor.Clone();

        for (int i = 0; i < k; i++)
        {
            int escolhido = i;

            for (int j = i + 1; j < copia.Length; j++)
            {
                if (tipoBusca == TipoBusca.Menores)
                {
                    if (copia[j] < copia[escolhido])
                    {
                        escolhido = j;
                    }
                }
                else
                {
                    if (copia[j] > copia[escolhido])
                    {
                        escolhido = j;
                    }
                }
            }

            int temp = copia[i];
            copia[i] = copia[escolhido];
            copia[escolhido] = temp;
        }

        int[] resultado = new int[k];

        Array.Copy(copia, resultado, k);

        return resultado;
    }
}