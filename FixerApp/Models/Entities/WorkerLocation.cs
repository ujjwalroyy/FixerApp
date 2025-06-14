namespace FixerApp.Models.Entities
{
    public class WorkerLocation
    {
        private long WorkerId { get; set; }

        private double Latitude { get; set; }
        private double Longitude { get; set; }

        private DateTime LastUpdated { get; set; }
    }
}
