namespace ApplicationCore.Entities
{
    public class Athlete : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public float Weight { get; private set; }
        public float Height { get; private set; }
        private Athlete()
        {
        }
        protected Athlete(string name, string surname, float weight, float height) : this()
        {
            Validate(name, surname, weight, height);

            Name = name;
            Surname = surname;
            Weight = weight;
            Height = height;
        }

        public static Athlete RegisterNew(string name, string surname, float weight, float height)
        {
            return new Athlete(name, surname, weight, height);
        }

        private static void Validate(string name, string surname, float weight, float height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new System.ArgumentException($"'{nameof(surname)}' cannot be null or whitespace.", nameof(surname));
            }

            if (height <= 0.00)
            {
                throw new System.ArgumentException($"'{nameof(height)}' must be greater then zero.", nameof(height));
            }

            if (weight <= 0.00)
            {
                throw new System.ArgumentException($"'{nameof(weight)}' must be greater then zero.", nameof(weight));
            }
        }
    }
}
