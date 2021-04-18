namespace ApplicationCore.Models.Requests
{
    public class RegisterAthleteRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Weight { get; set; }
        public float Height{ get; set; }
    }
}