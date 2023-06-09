using PolarC_task.Dtos;
using PolarC_task.TrafficLight;

namespace PolarC_task.Mappers
{
    // not worth to use automapper for few methods
    public class TrafficLightCustomMapper : ITrafficLightCustomMapper
    {
        public TrafficLightDto MapToDto(Light light)
        {
            if(light is null) 
            { 
                throw new ArgumentException("Not valid light entity"); 
            }

            return new TrafficLightDto
            {
                Id = (int)light.LightType,
                Color = light.LightType.ToString(),
                Duration = light.Duration,
                IsAfterGreen = light.IsAfterGreen
            };
        }
    }
}
