using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Controllers;
using ArtIsPain.Server.Data;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.Handlers.Band;
using ArtIsPain.Server.ViewModels.Album;
using ArtIsPain.Server.ViewModels.Band;
using ArtIsPain.Shared.Models;
using ArtIsPain.UnitTests.Providers;
using AutoMapper;
using Faker;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task BandsController_GetBandByIdCommand()
        {
            //Mock<IMapper> autoMapperMock = new Mock<IMapper>();
            //Mock<IRepository<Band>> bandRepositoryMock = new Mock<IRepository<Band>>();
            //Mock<IMediator> mediatorMock = new Mock<IMediator>();
            //Mock<DbSet<Band>> bandTableMock = new Mock<DbSet<Band>>();

            //Guid bandId = Guid.NewGuid();
            //BandViewModel band = new BandViewModel
            //{
            //    Id = bandId,
            //    Description = StringFaker.Alpha(5000),
            //    Name = StringFaker.Alpha(255),
            //    DisbandDate = DateTimeFaker.DateTime().ToString(),
            //    FormationDate = DateTimeFaker.DateTime().ToString(),
            //    Albums = new List<AlbumPreviewModel>
            //    {
            //            new AlbumPreviewModel
            //        {
            //            Id = Guid.NewGuid(),
            //            Band = new BandPreviewModel
            //            {
            //                Id = bandId,
            //                Title = StringFaker.Alpha(255)
            //            }
            //        }
            //    }
            //};

            //Band bandToReturn = new Band
            //{
            //    Id = bandId,
            //    Description = StringFaker.Alpha(5000),
            //    Title = StringFaker.Alpha(255),
            //    StartActivityDate = DateTimeFaker.DateTime(),
            //    EndActivityDate = DateTimeFaker.DateTime()
            //};


            //IQueryable<Band> list = new List<Band> { bandToReturn }.AsQueryable();

            //bandTableMock.As<IDbAsyncEnumerable<Band>>()
            //    .Setup(m => m.GetAsyncEnumerator())
            //    .Returns(new TestDbAsyncEnumerator<Band>(list.GetEnumerator()));

            //bandTableMock.As<IQueryable<Band>>().Setup(m => m.Expression).Returns(list.Expression);
            //bandTableMock.As<IQueryable<Band>>().Setup(m => m.ElementType).Returns(list.ElementType);
            //bandTableMock.As<IQueryable<Band>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            //Mock<DataContext> dataContextMock = new Mock<DataContext>(new DbContextOptions<DataContext>(), null);
            //dataContextMock.Setup(c => c.Bands).Returns(bandTableMock.Object);
            //dataContextMock.Setup(c => c.Set<Band>()).Returns(bandTableMock.Object);

            //var service = new BandRepository(dataContextMock.Object);
            //Band result = await service.GetById(bandId).FirstOrDefaultAsync();

            //result.Should().Be(bandToReturn);

            DateTime.Now.Should().BeAfter(DateTime.Now);
        }
    }
}
