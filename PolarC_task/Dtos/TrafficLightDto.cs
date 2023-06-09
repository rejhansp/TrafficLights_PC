namespace PolarC_task.Dtos
{
    public class TrafficLightDto
    {
        public int Id { get; set; }

        public int Duration { get; set; }
        
        public string Color { get; set; } = string.Empty;

        public bool IsAfterGreen { get; set; }

        public bool HasPedestrianInvokedRed { get; set; }

    }
}