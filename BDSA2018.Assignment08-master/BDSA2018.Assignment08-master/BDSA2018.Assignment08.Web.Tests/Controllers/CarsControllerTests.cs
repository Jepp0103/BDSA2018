using BDSA2018.Assignment08.Models;
using BDSA2018.Assignment08.Shared;
using BDSA2018.Assignment08.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BDSA2018.Assignment08.Web.Tests.Controllers
{
    public class CarsControllerTests
    {
        [Fact]
        public async Task Get_returns_dtos()
        {
            var dto = new CarDTO();
            var all = new[] { dto }.AsQueryable().BuildMock();
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.Read()).Returns(all.Object);

            var controller = new CarsController(repository.Object);

            var result = await controller.Get();

            Assert.Equal(dto, result.Value.Single());
        }

        [Fact]
        public async Task Get_given_existing_id_returns_dto()
        {
            var dto = new CarDTO();
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.FindAsync(42)).ReturnsAsync(dto);

            var controller = new CarsController(repository.Object);

            var get = await controller.Get(42);

            Assert.Equal(dto, get.Value);
        }

        [Fact]
        public async Task Get_given_non_existing_id_returns_NotFound()
        {
            var repository = new Mock<ICarRepository>();

            var controller = new CarsController(repository.Object);

            var get = await controller.Get(42);

            Assert.IsType<NotFoundResult>(get.Result);
        }

        [Fact]
        public async Task GetImage_given_existing_id_returns_file()
        {
            var image = new byte[] { 1, 2, 3 };
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.FindImageAsync(42)).ReturnsAsync(image);

            var controller = new CarsController(repository.Object);

            var get = await controller.GetImage(42);

            var result = get.Result as FileContentResult;

            Assert.Equal(image, result.FileContents);
            Assert.Equal("image/jpeg", result.ContentType);
        }

        [Fact]
        public async Task GetImage_given_non_existing_id_returns_NotFound()
        {
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.FindImageAsync(42)).ReturnsAsync(default(byte[]));

            var controller = new CarsController(repository.Object);

            var get = await controller.GetImage(42);

            Assert.IsType<NotFoundResult>(get.Result);
        }

        [Fact]
        public async Task Post_given_dto_creates_car()
        {
            var output = new CarDTO();
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.CreateAsync(It.IsAny<CarCreateDTO>())).ReturnsAsync(output);

            var controller = new CarsController(repository.Object);

            var input = new CarCreateDTO();

            await controller.Post(input);

            repository.Verify(s => s.CreateAsync(input));
        }

        [Fact]
        public async Task Post_given_dto_returns_CreatedAtActionResult()
        {
            var input = new CarCreateDTO();
            var output = new CarDTO { Id = 42 };
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.CreateAsync(input)).ReturnsAsync(output);

            var controller = new CarsController(repository.Object);

            var post = await controller.Post(input);
            var result = post.Result as CreatedAtActionResult;

            Assert.Equal("Get", result.ActionName);
            Assert.Equal(42, result.RouteValues["id"]);
            Assert.Equal(output, result.Value);
        }

        [Fact]
        public async Task Put_given_dto_updates_car()
        {
            var repository = new Mock<ICarRepository>();

            var controller = new CarsController(repository.Object);

            var dto = new CarUpdateDTO();

            await controller.Put(42, dto);

            repository.Verify(s => s.UpdateAsync(dto));
        }

        [Fact]
        public async Task Put_returns_NoContent()
        {
            var dto = new CarUpdateDTO();
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.UpdateAsync(dto)).ReturnsAsync(true);
            var controller = new CarsController(repository.Object);

            var put = await controller.Put(42, dto);

            Assert.IsType<NoContentResult>(put);
        }

        [Fact]
        public async Task Put_given_repository_returns_false_returns_NotFound()
        {
            var repository = new Mock<ICarRepository>();

            var controller = new CarsController(repository.Object);

            var dto = new CarUpdateDTO();

            var put = await controller.Put(42, dto);

            Assert.IsType<NotFoundResult>(put);
        }

        [Fact]
        public async Task Delete_given_id_deletes_car()
        {
            var repository = new Mock<ICarRepository>();

            var controller = new CarsController(repository.Object);

            await controller.Delete(42);

            repository.Verify(s => s.DeleteAsync(42));
        }

        [Fact]
        public async Task Delete_returns_NoContent()
        {
            var repository = new Mock<ICarRepository>();
            repository.Setup(s => s.DeleteAsync(42)).ReturnsAsync(true);
            var controller = new CarsController(repository.Object);

            var delete = await controller.Delete(42);

            Assert.IsType<NoContentResult>(delete);
        }

        [Fact]
        public async Task Delete_given_repository_returns_false_returns_NotFound()
        {
            var repository = new Mock<ICarRepository>();

            var controller = new CarsController(repository.Object);

            var delete = await controller.Delete(42);

            Assert.IsType<NotFoundResult>(delete);
        }
    }
}
