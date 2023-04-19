using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightApp.Entities;
using FlightApp.PassengerHelpers.Dto;

namespace FlightApp
{
    public class CustomMapper
    {
        public static void CreateMapping(IMapperConfigurationExpression _configuration)
        {
            _configuration.CreateMap<Passenger, PassengerDto>().ReverseMap();
            //_configuration.CreateMap<FlightCode, PassengerDto>().ReverseMap();

        }
    }
}
