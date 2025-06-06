using Xunit;
using SafeZone.Domain.Entities;

namespace SafeZone.Tests.Tests
{
    public class AlertTests
    {
        [Fact]
        public void CriarAlert_DeveTerTituloCorreto()
        {
            // Arrange
            var alert = new Alert
            {
                Titulo = "Alerta de Enchente",
                Tipo = "chuva"
            };

            // Act & Assert
            Assert.Equal("Alerta de Enchente", alert.Titulo);
            Assert.Equal("chuva", alert.Tipo);
        }
    }
}
