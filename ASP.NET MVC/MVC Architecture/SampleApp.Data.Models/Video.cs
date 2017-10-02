using AutoMapper.Attributes;
using SampleApp.Data.Models.Abstracts;
using SampleApp.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Models
{
    public class Video : BaseModel, IAuditable, IDeletable
    {
        public string FilePath { get; set; }
    }
}
