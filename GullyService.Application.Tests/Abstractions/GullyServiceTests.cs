using GullyService.Application.Abstractions;
using GullyService.Application.Dtos;
using GullyService.Domain.Entities;
using GullyService.Infrastructure.Repository;
using Moq;

namespace GullyService.Application.Tests.Services
{
    public class GullyApplicationServiceTests
    {
        private readonly Mock<IGullyRepository> _repositoryMock;
        private readonly GullyApplicationService _service;

        public GullyApplicationServiceTests()
        {
            _repositoryMock = new Mock<IGullyRepository>();
            _service = new GullyApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public async Task AddGullyAsync_When_Save_Succeeds_Returns_GullyResponse()
        {
            // Arrange
            var request = new GullyRequest
            {
                Name = "Test Gully",
                Height = 100,
                Width = 50,
                PipeHeight = 30,
                PipeDiameter = 10,
                WaterHeight = 20
            };

            _repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Gully>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.AddGullyAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Error);

            Assert.Equal(request.Name, result.Name);
            Assert.Equal(request.Height, result.Height);
            Assert.Equal(request.Width, result.Width);
            Assert.Equal(request.PipeHeight, result.PipeHeight);
            Assert.Equal(request.PipeDiameter, result.PipeDiameter);
            Assert.Equal(request.WaterHeight, result.WaterHeight);

            _repositoryMock.Verify(
                r => r.AddAsync(It.Is<Gully>(g =>
                    g.Id != Guid.Empty &&
                    g.Name == request.Name &&
                    g.Height == request.Height &&
                    g.Width == request.Width &&
                    g.PipeHeight == request.PipeHeight &&
                    g.PipeDiameter == request.PipeDiameter &&
                    g.WaterHeight == request.WaterHeight
                )),
                Times.Once);
        }

        [Fact]
        public async Task AddGullyAsync_When_Repository_Throws_Exception_Is_Propagated()
        {
            // Arrange
            var request = new GullyRequest
            {
                Name = "Faulty Gully",
                Height = 100,
                Width = 50,
                PipeHeight = 30,
                PipeDiameter = 10,
                WaterHeight = 20
            };

            _repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Gully>()))
                .ThrowsAsync(new Exception("DB failure"));

            // Act + Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _service.AddGullyAsync(request));

            _repositoryMock.Verify(
                r => r.AddAsync(It.IsAny<Gully>()),
                Times.Once);
        }
    }
}
