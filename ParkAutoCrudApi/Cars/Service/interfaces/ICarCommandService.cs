using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Dto;

namespace ParkAutoCrudApi.Cars.Service.interfaces
{
    public interface ICarCommandService
    {
        Task<CarDto> CreateCar(CreateCarRequest request);
        Task<CarDto> UpdateCar(int id, UpdateCarRequest request);
        Task<CarDto> DeleteCar(int id);
    }
}
