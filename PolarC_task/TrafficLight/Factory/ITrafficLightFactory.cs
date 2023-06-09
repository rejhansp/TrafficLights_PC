namespace PolarC_task.TrafficLight.Factory
{
    public interface ITrafficLightFactory
    {
        Light CreateTrafficLight(LightType lightType);

        Light CreateTrafficLight(LightType lightType, int minDuration, int maxDuration);

        Light CreateNextTrafficLight(LightType lightType, bool isAfterGreen);
    }
}
