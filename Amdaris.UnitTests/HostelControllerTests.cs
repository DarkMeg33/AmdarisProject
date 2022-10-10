using AmdarisProject.Api.Controllersа;
using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Amdaris.UnitTests
{
    [TestFixture]
    internal class HostelControllerTests
    {
        [Test]
        public async Task GetHostelsAsync_ReturnsListOfHostels()
        {
            //Arrange
            var mock = new Mock<IHostelService>();
            mock.Setup(s => s.GetHostelsAsync()).ReturnsAsync(GetHostelDtos());
            var controller = new HostelsController(mock.Object);

            //Act
            var actionResult = await controller.GetHostels() as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(actionResult);
            //Assert.That(actionResult.Value, Is.EqualTo(GetHostelDtos()));
            Assert.AreEqual(GetHostelDtos(), actionResult.Value as List<HostelDto>);
        }

        public List<HostelDto> GetHostelDtos()
        {
            return new List<HostelDto>()
            {
                new HostelDto() { HostelNumber = 3 },
                new HostelDto() { HostelNumber = 4 },
                new HostelDto() { HostelNumber = 5 },
                new HostelDto() { HostelNumber = 6 },
                new HostelDto() { HostelNumber = 7 },
            };
        }
    }
}
