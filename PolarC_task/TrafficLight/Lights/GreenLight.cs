namespace PolarC_task.TrafficLight.Lights
{
    public class GreenLight : Light
    {
        public GreenLight(int minDuration, int maxDuration) : base(minDuration, maxDuration) { }

        public override LightType LightType => LightType.GREEN;

        public override void UpdateDuration()
        {
            throw new NotImplementedException();
        }
    }
}
