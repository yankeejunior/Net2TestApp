using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace FlightApp.PassengerHelpers.Dto
{
    public class PassengerDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string FlightDestination { get; set; }

        [Required]
        public DateTime FlightTime { get; set; }

        [Required]
        public string PassengerClass { get; set; }

        [Required]
        public string MealType { get; set; }


    }
}
