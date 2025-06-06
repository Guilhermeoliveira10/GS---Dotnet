using Xunit;
using Moq;
using SafeZone.Application.Services;
using SafeZone.Domain.Interfaces; // <- aqui está o fix!
using SafeZone.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SafeZone.Domain.Interfaces.Repositories;

namespace SafeZone.Tests
{
    public class HelpRequestServiceTests
    {
        [Fact]
        public async Task GetAll_ReturnsListOfHelpRequests()
        {
            // Arrange
            var mockRepo = new Mock<IHelpRequestRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<HelpRequest>
                {
                    new HelpRequest { Id = 1, Nome = "Ajuda com enchente", TipoAjuda = "Resgate", Localizacao = "Zona Norte" },
                    new HelpRequest { Id = 2, Nome = "Precisa de abrigo", TipoAjuda = "Abrigo", Localizacao = "Zona Sul" }
                });

            var service = new HelpRequestService(mockRepo.Object);

            // Act
            var result = await service.ListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, r => r.Nome == "Ajuda com enchente");
        }
    }
}
