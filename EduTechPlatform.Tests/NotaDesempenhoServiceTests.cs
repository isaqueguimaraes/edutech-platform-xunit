using Xunit;
using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class NotaDesempenhoServiceTests
{
    private readonly NotaDesempenhoService _service = new();

    [Theory]
    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)]
    public void CalcularMediaPonderada_DeveCalcularCorretamente(decimal n1, decimal n2, decimal nProj, decimal esperado)
    {
        decimal resultado = _service.CalcularMediaPonderada(n1, n2, nProj);
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(8.5, "APROVADO")]
    [InlineData(6.0, "RECUPERACAO")]
    [InlineData(4.2, "REPROVADO")]
    public void ObterSituacaoAcademica_DeveRetornarSituacaoCorreta(decimal media, string esperado)
    {
        string resultado = _service.ObterSituacaoAcademica(media);
        Assert.Equal(esperado, resultado);
    }
}