using Xunit;
using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class FrequenciaServiceTests
{
    private readonly FrequenciaService _service = new();

    [Theory]
    [InlineData(80, 20, 75.0)]
    [InlineData(100, 10, 90.0)]
    public void CalcularPorcentagemPresenca_DeveCalcularPercentualCorreto(int aulasTotais, int faltas, double esperado)
    {
        double resultado = _service.CalcularPorcentagemPresenca(aulasTotais, faltas);
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(80, 20, true)]
    [InlineData(80, 21, false)]
    public void AprovadoPorFrequencia_DeveValidarElegibilidade(int aulasTotais, int faltas, bool esperado)
    {
        bool resultado = _service.AprovadoPorFrequencia(aulasTotais, faltas);
        Assert.Equal(esperado, resultado);
    }
}