using Swashbuckle.AspNetCore.Annotations;

namespace ApplicationCore.Models.Requests
{
    public class RegisterAthleteRequest
    {
        public AthleteType AthleteType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
    }

    public enum AthleteType
    {
        Athlete = 0,
        Sprinter = 1,
        Lifter = 2
    }
}