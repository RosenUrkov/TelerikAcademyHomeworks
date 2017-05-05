namespace ProjectManager.Models
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;

    public interface IProject
    {
        string Name { get; }

        DateTime StartingDate { get; }

        DateTime EndingDate { get; }

        ProjectState State { get; }

        List<IUser> Users { get; }

        List<ITask> Tasks { get; }
    }
}
