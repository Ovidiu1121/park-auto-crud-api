namespace ParkAutoCrudApi.Dto;

public class ListCarDto
{
    public ListCarDto()
    {
        carList = new List<CarDto>();
    }
    public List<CarDto> carList { get; set; }
}