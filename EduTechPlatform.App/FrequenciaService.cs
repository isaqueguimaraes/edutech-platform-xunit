namespace EduTechPlatform.App;

public class FrequenciaService
{
    public double CalcularPorcentagemPresenca(int aulasTotais, int faltas)
    {
        return ((aulasTotais - faltas) / (double)aulasTotais) * 100.0;
    }

    public bool AprovadoPorFrequencia(int aulasTotais, int faltas)
    {
        double percentual = CalcularPorcentagemPresenca(aulasTotais, faltas);
        return percentual >= 75.0;
    }
}