using ProjectManager.Data.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.Data
{
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
