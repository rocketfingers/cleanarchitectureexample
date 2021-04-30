namespace ApplicationCore.Entities
{
    public class Sprinter : Athlete
    {
        public float TimeFor100m { get; private set; }
        public float TimeFor500m { get; private set; }
        public float TimeFor1000m { get; private set; }
        public float TimeFor3000m { get; private set; }
        private Sprinter(string name,
                         string surname,
                         float weight,
                         float height,
                         float timeFor100m,
                         float timeFor500m,
                         float timeFor1000m,
                         float timeFor3000m)
            : base(name, surname, weight, height)
        {
            TimeFor100m = timeFor100m;
            TimeFor500m = timeFor500m;
            TimeFor1000m = timeFor1000m;
            TimeFor3000m = timeFor3000m;
        }

        public static Sprinter RegisterNew(string name, string surname, float weight, float height, float timeFor100m, float timeFor500m, float timeFor1000m, float timeFor3000m)
        {
            return new Sprinter(name, surname, weight, height, timeFor100m, timeFor500m, timeFor500m, timeFor3000m);
        }
    }
}
