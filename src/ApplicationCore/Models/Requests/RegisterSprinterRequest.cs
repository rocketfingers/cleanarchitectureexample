namespace ApplicationCore.Models.Requests
{
    public class RegisterSprinterRequest : RegisterAthleteRequest
    {
        public float TimeFor100m { get; set; }
        public float TimeFor500m { get; set; }
        public float TimeFor1000m { get; set; }
        public float TimeFor3000m { get; set; }
    }
}