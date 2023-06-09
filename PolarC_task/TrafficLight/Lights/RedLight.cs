namespace PolarC_task.TrafficLight.Lights
{
    public class RedLight : Light
    {
        public RedLight(int minDuration, int maxDuration) : base(minDuration, maxDuration) { }

        public override LightType LightType => LightType.RED;
    }
}
