using SampleApp.Data.Models.Abstracts;
using SampleApp.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.Models
{
    public class Post : BaseModel, IAuditable, IDeletable
    {
    }
}
