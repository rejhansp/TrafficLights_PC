using PolarC_task.TrafficLight.Lights;

namespace PolarC_task.TrafficLight.Factory
{
    public class TrafficLightFactory : ITrafficLightFactory
    {
        private readonly IConfiguration _config;

        public TrafficLightFactory(IConfiguration configuration) => _config = configuration;
        

        public Light CreateTrafficLight(LightType lightType)
        {
            return lightType switch
            {
                LightType.RED =>
                    new RedLight(_config.GetValue<int>("TrafficLights:RedLightMinDuration"), _config.GetValue<int>("TrafficLights:RedLightMaxDuration")),
                LightType.YELLOW => 
                    new YellowLight(_config.GetValue<int>("TrafficLights:YellowLightMinDuration"), _config.GetValue<int>("TrafficLights:YellowLightMaxDuration")),
                LightType.GREEN =>
                    new GreenLight(_config.GetValue<int>("TrafficLights:GreenLightMinDuration"), _config.GetValue<int>("TrafficLights:GreenLightMaxDuration")),
                _ => throw new ArgumentException("Invalid traffic light type")
            };
        }

        public Light CreateTrafficLight(LightType lightType, int minDuration, int maxDuration)
        {
            return lightType switch
            {
                LightType.RED => new RedLight(minDuration, maxDuration),
                LightType.YELLOW => new YellowLight(minDuration, maxDuration),
                LightType.GREEN => new GreenLight(minDuration, maxDuration),
                _ => throw new ArgumentException("Invalid traffic light type")
            };
        }

        public Light CreateNextTrafficLight(LightType lightType, bool isAfterGreen)
        {
            return lightType switch
            {
                // transition to YELLOW after RED;
                LightType.RED =>
                    new YellowLight(_config.GetValue<int>("TrafficLights:YellowLightMinDuration"), _config.GetValue<int>("TrafficLights:YellowLightMaxDuration")),
                
                // transition to YELLOW after GREEN and remember the previous color;
                LightType.GREEN =>
                    new YellowLight(_config.GetValue<int>("TrafficLights:YellowLightMinDuration"), _config.GetValue<int>("TrafficLights:YellowLightMaxDuration"), true),
                
                (LightType.YELLOW) =>
                    
                    // transition to RED after YELLOW if previous color was GREEN
                    isAfterGreen 
                        ? new RedLight(_config.GetValue<int>("TrafficLights:RedLightMinDuration"), _config.GetValue<int>("TrafficLights:RedLightMaxDuration"))
                        : new GreenLight(_config.GetValue<int>("TrafficLights:GreenLightMinDuration"), _config.GetValue<int>("TrafficLights:GreenLightMaxDuration")),

                _ => throw new ArgumentException("Invalid traffic light type")
            };
        }
    }
}
