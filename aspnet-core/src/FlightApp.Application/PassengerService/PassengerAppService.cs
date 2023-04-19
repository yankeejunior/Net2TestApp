using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Net.Mail;
using AutoMapper.Internal.Mappers;
using FlightApp.Constants;
using FlightApp.Entities;
using FlightApp.PassengerHelpers.Dto;

namespace FlightApp.PassengerService
{
    public class PassengerAppService : AsyncCrudAppService<Passenger, PassengerDto>, IPassengerAppService
    {
        private readonly IRepository<Passenger, int> _passengerRepository;
        private readonly IRepository<FlightCode, int> _flightCodeRepository;
        public readonly IEmailSender _emailSender;
        public PassengerAppService(IRepository<Passenger, int> repository, IRepository<Passenger, int> passengerRepository, IRepository<FlightCode, int> flightCodeRepository, IEmailSender emailSender) : base(repository)
        {
            _passengerRepository = passengerRepository;
            _flightCodeRepository = flightCodeRepository;
            _emailSender = emailSender;
        }

        public async Task<string> CreatePassanger(PassengerDto input)
        {
            var passenger = ObjectMapper.Map<Passenger>(input);

            var passengerId = await _passengerRepository.InsertAndGetIdAsync(passenger);

            var code = FlightCodeGenerator(input);

            var flightCode = new FlightCode()
            {
                PassengerId = passengerId,
                Code = code
            };

            await _flightCodeRepository.InsertAsync(flightCode);

            SendEmailToTheUser(input.Email, code);

            return code;
        }

        private void SendEmailToTheUser(string email, string code)
        {
            try
            {
                _emailSender.Send(
                    to: email,
                    subject: "You got your flight code",
                    body: $"Your flight code is <b>{code}</b>",
                    isBodyHtml: true
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
          
        }

        private string FlightCodeGenerator(PassengerDto input)
        {
            var code = "";

            // Set Flight Destination code
            if (!input.FlightDestination.IsNullOrWhiteSpace())
            {

                var isNightFlight = IsNightFlight(input.FlightTime);

                switch (input.FlightDestination)
                {
                    case "Uk":
                        code += isNightFlight == true ? FlightConstants.UkDest.ToLower() : FlightConstants.UkDest;
                        break;
                    case "Europe":
                        code += isNightFlight == true ? FlightConstants.EuropeDes.ToLower() : FlightConstants.EuropeDes;
                        break;
                    case "Asian":
                        code += isNightFlight == true ? FlightConstants.AsianDes.ToLower() : FlightConstants.AsianDes;
                        break;
                    case "Americas":
                        code += isNightFlight == true ? FlightConstants.AsianDes.ToLower(): FlightConstants.AsianDes;
                        break;
                }
            }
            // Set Gender Code

            if (!input.Gender.IsNullOrWhiteSpace())
            {

                var isChildren = ChildrenValidator(input.Birthdate);

                switch (input.Gender)
                {
                    case "Male":
                        code +=  isChildren == true ?  FlightConstants.MalePass.ToLower() : FlightConstants.UkDest;
                        break;
                    case "Female":
                        code += isChildren == true ?  FlightConstants.FemalePass.ToLower() : FlightConstants.UkDest;
                        break;
                }
            }

            // Set Meals Code

            if (!input.MealType.IsNullOrWhiteSpace())
            {

                var isChildren = ChildrenValidator(input.Birthdate);

                switch (input.MealType)
                {
                    case "European":
                        code += isChildren == true ? FlightConstants.EuropeMeals.ToLower() : FlightConstants.EuropeMeals;
                        break;
                    case "Asian":
                        code += isChildren == true ? FlightConstants.AsianMeals.ToLower() : FlightConstants.AsianMeals;
                        break;
                    case "Vegetarian":
                        code += isChildren == true ? FlightConstants.VegetarianMeals.ToLower() : FlightConstants.VegetarianMeals;
                        break;
                }
            }

            // Set passenger class code
            if (!input.PassengerClass.IsNullOrWhiteSpace())
            {
                switch (input.PassengerClass)
                {
                    case "First Class":
                        code += FlightConstants.FirstClass;
                        break;
                    case "Business":
                        code += FlightConstants.BusinessClass;
                        break;
                    case "Economy":
                        code += FlightConstants.EconomyClass;
                        break;
                }
            }

            if (input.Nationality == "Europe")
            {
                code += "-EU";
            }
            else
            {
                code += "-ZZ";
            }



            return code;
        }

        private bool IsNightFlight(DateTime flightTime)
        {
            var timeOfDay = flightTime.TimeOfDay.Hours;
            if (timeOfDay >= 22 || timeOfDay <= 6)
            {
                return true;
            }

            return false;
        }

        private bool ChildrenValidator(DateTime birthday)
        {
            if (birthday.AddYears(12) > DateTime.Now)
            {
                return true;
            }

            return false;
        }

        public List<string> GetDestinations()
        {

            return new List<string>()
            {
                "UK",
                "Europe",
                "Asian",
                "Americas"
            };
        }

        public List<string> GetMeals()
        {
            return new List<string>()
            {
                "European",
                "Asian",
                "Vegetarian",
            };
        }

        public List<string> GetGenders()
        {
            return new List<string>()
            {
                "Male",
                "Female"
            };
        }

        public List<string> GetFlightClass()
        {
            return new List<string>()
            {
                "First Class",
                "Business",
                "Economy"
            };
        }
    }
}
