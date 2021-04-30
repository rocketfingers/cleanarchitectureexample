using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Lifter : Athlete
    {
        public float TotalWeight { get; set; }
        private Lifter(string name,
                      string surname,
                      float weight,
                      float height,
                      float totalWeight) : base(name, surname, weight, height)
        {
            TotalWeight = totalWeight;
        }
        public static Lifter RegisterNew(string name, string surname, float weight, float height, float totalWeight)
        {
            return new Lifter(name, surname, weight, height, totalWeight);
        }
    }
}
