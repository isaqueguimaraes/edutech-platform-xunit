using Xunit;
using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class MatriculaFinanceiraServiceTests
{
    private readonly MatriculaFinanceiraService _service = new();

    [Theory]
    [InlineData(1000.00, 10, true, 500.00)]
    [InlineData(1000.00, 4, false, 900.00)]
    [InlineData(1000.00, 10, false, 1000.00)]
    public void CalcularValorMensalidade_DeveAplicarDescontosCorretos(decimal valorBase, int diaPagamento, bool eBolsista, decimal esperado)
    {
        decimal resultado = _service.CalcularValorMensalidade(valorBase, diaPagamento, eBolsista);
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(false, "APROVADO", true)]
    [InlineData(true, "APROVADO", false)]
    [InlineData(false, "REPROVADO", false)]
    public void PodeRealizarRematricula_DeveValidarPendenciasESituacao(bool temPendencia, string situacao, bool esperado)
    {
        bool resultado = _service.PodeRealizarRematricula(temPendencia, situacao);
        Assert.Equal(esperado, resultado);
    }
}