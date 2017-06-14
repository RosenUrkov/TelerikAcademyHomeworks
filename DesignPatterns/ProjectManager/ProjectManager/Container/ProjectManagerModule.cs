using System;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Providers;
using ProjectManager.Commands.Contracts;
using Ninject.Extensions.Factory;
using Ninject;
using System.Linq;
using ProjectManager.Commands.Creational;
using ProjectManager.Commands.Listing;

namespace ProjectManager.Container
{
    public class ProjectManagerModule : NinjectModule
    {
        public const string EngineName = "Engine";

        public const string CreateProjectCommandName = "CreateProjectCommand";
        public const string CreateTaskCommandName = "CreateTaskCommand";
        public const string CreateUserCommandName = "CreateUserCommand";
        public const string ListProjectDetailsCommandName = "ListProjectDetailsCommand";
        public const string ListProjectsCommandName = "ListProjectsCommand";

        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named(EngineName);

            this.Bind<ILogger>().To<FileLogger>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            this.Bind<ICommand>().To<CreateProjectCommand>().InSingletonScope().Named(CreateProjectCommandName);
            this.Bind<ICommand>().To<CreateTaskCommand>().InSingletonScope().Named(CreateTaskCommandName);
            this.Bind<ICommand>().To<CreateUserCommand>().InSingletonScope().Named(CreateUserCommandName);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().InSingletonScope().Named(ListProjectDetailsCommandName);
            this.Bind<ICommand>().To<ListProjectsCommand>().InSingletonScope().Named(ListProjectsCommandName);

            this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommand>().ToMethod(context =>
            {
                return context.Kernel.Get<ICommand>(context.Parameters.First().GetValue(context,null).ToString());
            }).NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommand(null));           
        }
    }
}
