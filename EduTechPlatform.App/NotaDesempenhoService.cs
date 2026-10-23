namespace EduTechPlatform.App;

public class NotaDesempenhoService
{
    public decimal CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)
    {
        return ((nota1 * 3m) + (nota2 * 3m) + (notaProjeto * 4m)) / 10m;
    }

    public string ObterSituacaoAcademica(decimal mediaFinal)
    {
        if (mediaFinal >= 7.0m)
        {
            return "APROVADO";
        }
        else if (mediaFinal >= 5.0m)
        {
            return "RECUPERACAO";
        }
        else
        {
            return "REPROVADO";
        }
    }
}