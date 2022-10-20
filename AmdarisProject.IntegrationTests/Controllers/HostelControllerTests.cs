using System.Net;
using System.Net.Http.Json;
using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;

namespace AmdarisProject.IntegrationTests.Controllers
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
                new HostelDto() { Id = 1, HostelNumber = 3 },
                new HostelDto() { Id = 2, HostelNumber = 4 },
                new HostelDto() { Id = 3, HostelNumber = 5 },
                new HostelDto() { Id = 4, HostelNumber = 6 },
                new HostelDto() { Id = 5, HostelNumber = 7 },
            };
        }

        [Test]
        public async Task GetHostels_ShouldReturnsListOfHostelsDtos()
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
        public async Task GetHostel_ShouldReturnHostelDto()
        {
            //Arrange
            var id = 5; 

            _hostelService
                .Setup(s => s.GetHostelByIdAsync(id))
                .ReturnsAsync(GetHostelDtos().FirstOrDefault(h => h.Id == id));

            //Act
            var response = await _httpClient.GetAsync($"api/hostels/{id}");
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var json = await response.Content.ReadAsStringAsync();
            var hostel = JsonConvert.DeserializeObject<HostelDto>(json);

            Assert.That(hostel.Id, Is.EqualTo(id));
        }

        [Test]
        public async Task CreateHostel_ShouldReturnSuccessCreatedResponse()
        {
            //Arrange
            var hostelUpdateDto = new HostelUpdateDto()
            {
                HostelNumber = 2
            };

            _hostelService
                .Setup(s => s.CreateHostelAsync(It.Is<HostelUpdateDto>(x 
                        => x.HostelNumber == hostelUpdateDto.HostelNumber)))
                .ReturnsAsync(new HostelDto()
                {
                    Id = 6,
                    HostelNumber = hostelUpdateDto.HostelNumber
                });

            //Act
            var hostelJson = JsonContent.Create(hostelUpdateDto);
            var response = await _httpClient.PostAsync($"api/hostels", hostelJson);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            var json = await response.Content.ReadAsStringAsync();
            var hostel = JsonConvert.DeserializeObject<HostelDto>(json);

            Assert.That(hostel.Id, Is.EqualTo(6));
        }

        [Test]
        public async Task CreateHostel_ShouldReturnBadRequest()
        {
            //Arrange
            var hostelUpdateDto = new HostelUpdateDto()
            {
                HostelNumber = -1
            };

            _hostelService
                .Setup(s => s.CreateHostelAsync(It.Is<HostelUpdateDto>(x
                    => x.HostelNumber == hostelUpdateDto.HostelNumber)))
                .ReturnsAsync(() => null);

            //Act
            var hostelJson = JsonContent.Create(hostelUpdateDto);
            var response = await _httpClient.PostAsync($"api/hostels", hostelJson);

            //Arrange
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            //var json = await response.Content.ReadAsStringAsync();
            //var hostel = JsonConvert.DeserializeObject<ModelStateDictionary>(json);

            //Assert.That(hostel.ValidationState, Is.EqualTo(ModelValidationState.Invalid));
        }
        
        [Test]
        public async Task UpdateHostel_ShouldReturnNoContentResult()
        {
            //Arrange
            var id = 3;
            var hostelUpdateDto = new HostelUpdateDto()
            {
                HostelNumber = 7
            };

            _hostelService
                .Setup(s
                    => s.UpdateHostelAsync(id, It.Is<HostelUpdateDto>(h
                        => h.HostelNumber == hostelUpdateDto.HostelNumber)))
                .ReturnsAsync(GetHostelDtos().FirstOrDefault(h => h.Id == id));

            _hostelService
                .Setup(s => s.GetHostelByIdAsync(id))
                .ReturnsAsync(new HostelDto()
                {
                    Id = id,
                    HostelNumber = hostelUpdateDto.HostelNumber
                });

            //Act
            var hostelJson = JsonContent.Create(hostelUpdateDto);
            var response = await _httpClient.PutAsync($"api/hostels/{id}", hostelJson);

            var getResponse = await _httpClient.GetAsync($"api/hostels/{id}");

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var json = await getResponse.Content.ReadAsStringAsync();
            var hostel = JsonConvert.DeserializeObject<HostelDto>(json);

            Assert.That(hostel.Id, Is.EqualTo(id));
            Assert.That(hostel.HostelNumber, Is.EqualTo(hostelUpdateDto.HostelNumber));
        }

        [Test]
        public async Task UpdateHostel_ShouldReturnBadRequest()
        {
            //Arrange
            var id = 5;
            var hostelUpdateDto = new HostelUpdateDto()
            {
                HostelNumber = -1
            };

            _hostelService
                .Setup(s => s.UpdateHostelAsync(id, It.Is<HostelUpdateDto>(h
                    => h.HostelNumber == hostelUpdateDto.HostelNumber)))
                .ReturnsAsync(() => null);

            //Act
            var hostelJson = JsonContent.Create(hostelUpdateDto);
            var response = await _httpClient.PutAsync($"api/hostels/{id}", hostelJson);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task DeleteHostel_ShouldReturnNoContent()
        {
            //Act
            int id = 5;

            _hostelService
                .Setup(s => s.DeleteHostelAsync(id))
                .Returns(Task.CompletedTask);

            //Arrange
            var response = await _httpClient.DeleteAsync($"api/hostels/{id}");

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}
