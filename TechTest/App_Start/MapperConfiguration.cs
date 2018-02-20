using AutoMapper;
using Models.Models;
using Models.ViewModels;
using System.Collections.Generic;

namespace TechTest.App_Start
{
    public class MapperConfiguration
    {
        public static IConfigurationProvider Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonViewModel>()
                 .ForMember(x => x.FullName, opt => opt.Ignore())
                 .ForMember(x => x.ColourIds, opt => opt.Ignore());

                cfg.CreateMap<Colour, ColourViewModel>();
            });

            return Mapper.Configuration;
        }
    }
}