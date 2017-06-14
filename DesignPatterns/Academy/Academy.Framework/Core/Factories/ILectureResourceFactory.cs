using Academy.Models.Contracts;
using System;

namespace Academy.Framework.Core.Factories
{
    public interface ILectureResourceFactory
    {
        ILectureResource GetLectureResource(string type, string name, string url);
    }
}
