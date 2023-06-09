namespace PolarC_task.TrafficLight
{
    public abstract class Light
    {
        protected int MinDuration;
        protected int MaxDuration;
        public int Duration;

        public abstract LightType LightType { get; }
        public virtual bool IsAfterGreen { get; set; } = false;
        public virtual bool HasPedestrianInvokedRed { get; set; }

        public Light(int minDuration, int maxDuration, bool isAfterGreen = false)
        {
            MinDuration = minDuration;
            MaxDuration = maxDuration;
            IsAfterGreen = isAfterGreen;
            Duration = new Random().Next(MinDuration, MaxDuration + 1);
        }

        public virtual void UpdateDuration() { }

    }
}
