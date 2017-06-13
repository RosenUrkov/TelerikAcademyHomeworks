using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IMarkFactory
    {
        Mark CreateMark(Subject subject, float value);
    }
}
