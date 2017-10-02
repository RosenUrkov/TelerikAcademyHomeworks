using AutoMapper.Attributes;
using SampleApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SampleApp.Models
{
    public class Video : IMap<Data.Models.Video>, IHaveCustomMappings
    {
        public string FilePathString { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Data.Models.Video, Video>()
                .ForMember(x => x.FilePathString, cfg => cfg.MapFrom(y => y.FilePath));
        }
    }
}