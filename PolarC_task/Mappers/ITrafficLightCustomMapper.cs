using PolarC_task.Dtos;
using PolarC_task.TrafficLight;

namespace PolarC_task.Mappers
{
    public interface ITrafficLightCustomMapper
    {
        TrafficLightDto MapToDto(Light lights);
    }
}
