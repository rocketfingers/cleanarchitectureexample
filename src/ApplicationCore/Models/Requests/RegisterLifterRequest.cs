using System;

namespace ApplicationCore.Models.Requests
{
    public class RegisterLifterRequest : RegisterAthleteRequest
    {
        public float TotalWeight { get; set; }
        public Guid SomeGuid { get; set; }
        public DateTime SomeDate { get; set; }

    }
}