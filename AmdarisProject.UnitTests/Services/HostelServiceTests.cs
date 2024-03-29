﻿using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.Core.Services;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;
using Moq;

namespace AmdarisProject.UnitTests.Services
{
    [TestFixture]
    internal class HostelServiceTests
    {
        private IMapper _mapper;
        private List<Hostel> _hostels;
        private Mock<IHostelRepository> _repo;
        private IHostelService _hostelService;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _hostels = new List<Hostel>()
            {
                new Hostel() { Id = 1, HostelNumber = 3 },
                new Hostel() { Id = 2, HostelNumber = 4 },
                new Hostel() { Id = 5, HostelNumber = 7 },
                new Hostel() { Id = 3, HostelNumber = 5 },
                new Hostel() { Id = 4, HostelNumber = 6 },
            };

            _mapper = new Mapper(new MapperConfiguration(cfg 
                => cfg.CreateMap<Hostel, HostelDto>()));

            _repo = new Mock<IHostelRepository>();
            _hostelService = new HostelService(_repo.Object, _mapper);
        }

        [Test]
        public async Task GetHostelsAsync_ShouldReturnListOfHostels()
        {
            //Arrange
            _repo.Setup(r => r.GetAllAsync()).ReturnsAsync(_hostels);

            //Act
            var hostels = await _hostelService.GetHostelsAsync();

            //Assert
            Assert.NotNull(hostels);
            Assert.That(hostels.Count, Is.EqualTo(_hostels.Count));

            var sortedHostels = hostels.TakeWhile((h, i)
                => h.HostelNumber == _hostels[i].HostelNumber &&
                   h.Id == _hostels[i].Id).ToList();

            Assert.That(sortedHostels.Count, Is.EqualTo(_hostels.Count));
        }

        [Test]
        public async Task GetHostelByIdAsync_ShouldReturnHostelDto()
        {
            //Arrange
            var id = 5;

            _repo
                .Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(_hostels.FirstOrDefault(x => x.Id == id));

            //Act
            var hostel = await _hostelService.GetHostelByIdAsync(id);

            //Assert
            Assert.IsNotNull(hostel);
            Assert.That(hostel.Id, Is.EqualTo(id));
            Assert.That(hostel.HostelNumber, Is.EqualTo(_hostels.FirstOrDefault(x => x.Id == id)?.HostelNumber));
        }
    }
}
