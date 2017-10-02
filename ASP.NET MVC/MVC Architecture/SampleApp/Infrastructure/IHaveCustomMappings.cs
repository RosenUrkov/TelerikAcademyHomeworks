using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApp.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}