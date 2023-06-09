namespace PolarC_task.TrafficLight.Lights
{
    public class YellowLight : Light
    {
        public YellowLight(int minDuration, int maxDuration, bool isAfterGreen = false) 
            : base(minDuration, maxDuration, isAfterGreen) { }

        public override LightType LightType => LightType.YELLOW;
    }
}
