using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace FlightApp.Entities
{
    [Table("Passengers", Schema = "flights")]
    public class Passenger : Entity<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string FlightDestination { get; set; }

        public DateTime FlightTime { get; set; }

        public string PassengerClass { get; set;}

        public string MealType { get; set; }
    }
}
