namespace OrdenacaoPartial.Projeto.Models;


public static class GeradorVetores
{
    public static int[] Gerar(
        int tamanho,
        TipoVetor tipo)
    {
        int[] vetor = new int[tamanho];

        Random random = new();

        switch (tipo)
        {
            case TipoVetor.Crescente:

                for (int i = 0; i < tamanho; i++)
                    vetor[i] = i;

                break;

            case TipoVetor.Decrescente:

                for (int i = 0; i < tamanho; i++)
                    vetor[i] = tamanho - i;

                break;

            case TipoVetor.Aleatorio:

                for (int i = 0; i < tamanho; i++)
                    vetor[i] = random.Next(1, 100000);

                break;
        }

        return vetor;
    }
}