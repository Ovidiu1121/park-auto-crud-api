using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Dto;

namespace ParkAutoCrudApi.Cars.Service.interfaces
{
    public interface ICarQueryService
    {
        Task<ListCarDto> GetAllCar();
        Task<CarDto> GetByBrand(string brand);
        Task<CarDto> GetById(int id);
    }
}
