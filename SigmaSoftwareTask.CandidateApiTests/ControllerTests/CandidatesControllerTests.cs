using Microsoft.AspNetCore.Mvc;
using Moq;
using SigmaSoftwareTask.CandidateApi.Controllers;
using SigmaSoftwareTask.CandidateApi.Dtos;
using SigmaSoftwareTask.CandidateApi.Mappers;
using SigmaSoftwareTask.CandidateApi.Models;
using SigmaSoftwareTask.CandidateApi.Services;


namespace SigmaSoftwareTask.CandidateApiTests.ControllerTests
{
    public class CandidatesControllerTests
    {
        [Fact]
        public async Task GetAllCandidates_ReturnsCandidates()
        {
            var mockCandidateService = new Mock<ICandidateService>();
            mockCandidateService.Setup(service => service.GetAllCandidatesAsync())
                .ReturnsAsync(new List<Candidate> {
                    new Candidate {  FirstName = "John", LastName = "Doe", Email = "JohnDoe@example.com", FreeTextComment = "comment" },
                    new Candidate {  FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com", FreeTextComment = "comment" }
                });

            var mockCandidateMapper = new Mock<ICandidateMapper>();
            var controller = new CandidatesController(mockCandidateService.Object, mockCandidateMapper.Object);

            var result = await controller.GetAllCandidates();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Candidate>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var candidates = Assert.IsAssignableFrom<IEnumerable<Candidate>>(okObjectResult.Value);
            Assert.Equal(2, candidates.Count());
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_ValidCandidateDto_ReturnsOkResult()
        {
            // Arrange
            var mockCandidateService = new Mock<ICandidateService>();
            var mockCandidateMapper = new Mock<ICandidateMapper>();
            var controller = new CandidatesController(mockCandidateService.Object, mockCandidateMapper.Object);
            var candidateDto = new CandidateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "JohnDoe@example.com",
                FreeTextComment = "Test comment"
            };

            // Act
            var result = await controller.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            mockCandidateService.Verify(service => service.AddOrUpdateCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }
    }
}
