using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace Amdaris.UnitTests.Controllers
{
    [TestFixture]
    internal class HostelControllerTests
    {
        private Mock<IHostelService> _hostelService;

        private HttpClient _httpClient;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _hostelService = new Mock<IHostelService>();

            var server = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(s =>
                    {
                        s.AddSingleton(_hostelService.Object);
                    });
                });

            _httpClient = server.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
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

        [Test]
        public async Task GetHostelsAsync_ShouldReturnsListOfHostelsDtos()
        {
            //Act
            _hostelService.Setup(s => s.GetHostelsAsync()).ReturnsAsync(GetHostelDtos());

            var response = await _httpClient.GetAsync($"api/hostels");
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var json = await response.Content.ReadAsStringAsync();
            var hostels = JsonConvert.DeserializeObject<List<HostelDto>>(json);

            Assert.That(hostels.Count, Is.EqualTo(GetHostelDtos().Count));
        }

        [Test]
        public async Task GetHostelByIdAsync_ShouldReturnHostelDto()
        {
            //Arrange
            var id = 5;

            //Act
            _hostelService.Setup(s => s.GetHostelByIdAsync(id)).ReturnsAsync(new HostelDto()
            {
                HostelNumber = 3
            });

            var response = await _httpClient.GetAsync($"api/hostels/{id}");
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var json = await response.Content.ReadAsStringAsync();
            var hostel = JsonConvert.DeserializeObject<HostelDto>(json);

            Assert.That(hostel.HostelNumber, Is.EqualTo(3));
        }
    }
}
