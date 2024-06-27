using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParkAutoCrudApi.Cars.Controller;
using ParkAutoCrudApi.Cars.Controller.interfaces;
using ParkAutoCrudApi.Cars.Service.interfaces;
using ParkAutoCrudApi.Dto;
using ParkAutoCrudApi.System.Constant;
using ParkAutoCrudApi.System.Exceptions;
using tests.Helpers;
using Xunit;

namespace tests.UnitTests;

public class TestController
{
    
    Mock<ICarCommandService> _command;
    Mock<ICarQueryService> _query;
    CarApiController _controller;

    public TestController()
    {
        _command = new Mock<ICarCommandService>();
        _query = new Mock<ICarQueryService>();
        _controller = new CarController(_command.Object, _query.Object);
    }
    
     [Fact]
    public async Task GetAll_ItemsDoNotExist()
    {
        _query.Setup(repo => repo.GetAllCar()).ThrowsAsync(new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST));
           
        var result = await _controller.GetAll();
        var notFound = Assert.IsType<NotFoundObjectResult>(result.Result);

        Assert.Equal(404, notFound.StatusCode);
        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, notFound.Value);
    }
    
    [Fact]
    public async Task GetAll_ValidData()
    {
        var cars = TestCarFactory.CreateCars(9);

        _query.Setup(repo => repo.GetAllCar()).ReturnsAsync(cars);

        var result = await _controller.GetAll();
        var okresult = Assert.IsType<OkObjectResult>(result.Result);
        var carsAll = Assert.IsType<ListCarDto>(okresult.Value);

        Assert.Equal(9, carsAll.carList.Count);
        Assert.Equal(200, okresult.StatusCode);
    }
    
    [Fact]
    public async Task Create_InvalidData()
    {

        var create = new CreateCarRequest()
        {
            Brand="test",
            Price=0,
            Horse_power= 0,
            Fabrication_year = 0
        };

        _command.Setup(repo => repo.CreateCar(It.IsAny<CreateCarRequest>())).ThrowsAsync(new ItemAlreadyExists(Constants.CAR_ALREADY_EXIST));

        var result = await _controller.CreateCar(create);

        var bad=Assert.IsType<BadRequestObjectResult>(result.Result);

        Assert.Equal(400,bad.StatusCode);
        Assert.Equal(Constants.CAR_ALREADY_EXIST, bad.Value);

    }
    
    [Fact]
    public async Task Create_ValidData()
    {

        var create = new CreateCarRequest()
        {
            Brand="test",
            Price=75000,
            Horse_power= 260,
            Fabrication_year = 1998
        };

        var car = TestCarFactory.CreateCar(2);

        car.Brand=create.Brand;
        car.Price=create.Price;
        car.Horse_power=create.Horse_power;
        car.Fabrication_year=create.Fabrication_year;

        _command.Setup(repo => repo.CreateCar(create)).ReturnsAsync(car);

        var result = await _controller.CreateCar(create);
        var okResult= Assert.IsType<CreatedResult>(result.Result);

        Assert.Equal(okResult.StatusCode, 201);
        Assert.Equal(car, okResult.Value);

    }
    
    [Fact]
    public async Task Update_InvalidDate()
    {
        var update = new UpdateCarRequest()
        {
            Brand="test",
            Price=0,
            Horse_power= 0,
            Fabrication_year = 0
        };

        _command.Setup(repo => repo.UpdateCar(33, update)).ThrowsAsync(new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST));

        var result = await _controller.UpdateCar(33, update);
        var bad = Assert.IsType<NotFoundObjectResult>(result.Result);

        Assert.Equal(bad.StatusCode, 404);
        Assert.Equal(bad.Value, Constants.CAR_DOES_NOT_EXIST);
    }
    
    [Fact]
    public async Task Update_ValidData()
    {
        var update = new UpdateCarRequest()
        {
            Brand="test",
            Price=75000,
            Horse_power= 260,
            Fabrication_year = 1998
        };

        var car=TestCarFactory.CreateCar(4);
        
        car.Brand=update.Brand;
        car.Price=update.Price.Value;
        car.Horse_power=update.Horse_power.Value;
        car.Fabrication_year=update.Fabrication_year.Value;

        _command.Setup(repo=>repo.UpdateCar(4,update)).ReturnsAsync(car);

        var result = await _controller.UpdateCar(4, update);
        var okResult=Assert.IsType<OkObjectResult>(result.Result);

        Assert.Equal(okResult.StatusCode, 200);
        Assert.Equal(okResult.Value, car);
    }
    
    [Fact]
    public async Task Delete_ItemDoesNotExist()
    {
        _command.Setup(repo=>repo.DeleteCar(1)).ThrowsAsync(new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST));

        var result= await _controller.DeleteCar(1);
        var notfound= Assert.IsType<NotFoundObjectResult>(result.Result);

        Assert.Equal(notfound.StatusCode, 404);
        Assert.Equal(notfound.Value, Constants.CAR_DOES_NOT_EXIST);
    }
    
    [Fact]
    public async Task Delete_ValidData()
    {
        var car = TestCarFactory.CreateCar(1);

        _command.Setup(repo => repo.DeleteCar(1)).ReturnsAsync(car);

        var result = await _controller.DeleteCar(1);
        var okResult=Assert.IsType<AcceptedResult>(result.Result);

        Assert.Equal(202, okResult.StatusCode);
        Assert.Equal(car, okResult.Value);
    }
    
}