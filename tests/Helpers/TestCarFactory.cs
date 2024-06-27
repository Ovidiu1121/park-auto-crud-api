using ParkAutoCrudApi.Dto;

namespace tests.Helpers;

public class TestCarFactory
{
    
    public static CarDto CreateCar(int id)
    {
        return new CarDto
        {
            Id = id,
            Brand="Audi"+id,
            Price=10000+id,
            Horse_power=300+id,
            Fabrication_year=2024+id
        };
    }

    public static ListCarDto CreateCars(int count)
    {
        ListCarDto cars=new ListCarDto();
            
        for(int i = 0; i<count; i++)
        {
            cars.carList.Add(CreateCar(i));
        }
        return cars;
    }
    
}