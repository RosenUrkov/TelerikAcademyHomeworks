using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System.IO;
using ProjectManager.Framework.Core;
using System.Reflection;
using ProjectManager.ConsoleClient.Configs;
using Ninject;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Data;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Core.Commands.Contracts;
using Ninject.Extensions.Factory;
using System.Linq;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Commands.Decorators;
using Ninject.Extensions.Interception.Infrastructure.Language;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public const string CreateProjectCommandName = "createproject";
        public const string CreateTaskCommandName = "createtask";
        public const string CreateUserCommandName = "createuser";
        public const string ListProjectDetailsCommandName = "listprojectdetails";
        public const string ListProjectsCommandName = "listprojects";

        public const string CachedListProjectsCommandName = "cachedlistprojects";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine) && type != typeof(Database) && type != typeof(CachingService))
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            this.Bind<ILogger>().To<FileLogger>()
                .InSingletonScope()
                .WithConstructorArgument(configurationProvider.LogFilePath);

            this.Bind<ICachingService>().To<CachingService>()
                .InSingletonScope()
                .WithConstructorArgument(configurationProvider.CacheDurationInSeconds);

            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope().Intercept().With<LogErrorInterceptor>();
            this.Kernel.InterceptAfter<CommandProcessor>(x => x.ProcessCommand(null), x => this.Kernel.Get<IWriter>().WriteLine(x.ReturnValue));

            this.Bind<ICommand>().To<CreateProjectCommand>().WhenParentNamed(CreateProjectCommandName).InSingletonScope();
            this.Bind<ICommand>().To<CreateTaskCommand>().WhenParentNamed(CreateTaskCommandName).InSingletonScope();
            this.Bind<ICommand>().To<CreateUserCommand>().WhenParentNamed(CreateUserCommandName).InSingletonScope();
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().WhenParentNamed(ListProjectDetailsCommandName).InSingletonScope();
            this.Bind<ICommand>().To<ListProjectsCommand>().WhenParentNamed(CachedListProjectsCommandName).InSingletonScope();

            this.Bind<ICommand>().To<ValidatableCommand>()
                .InSingletonScope()
                .Named(CreateProjectCommandName);

            this.Bind<ICommand>().To<ValidatableCommand>()
                .InSingletonScope()
                .Named(CreateTaskCommandName);

            this.Bind<ICommand>().To<ValidatableCommand>()
                .InSingletonScope()
                .Named(CreateUserCommandName);

            this.Bind<ICommand>().To<ValidatableCommand>()
                .InSingletonScope()
                .Named(ListProjectDetailsCommandName);

            this.Bind<ICommand>().To<CacheableCommand>()
                .WhenParentNamed(ListProjectsCommandName)
               .InSingletonScope()
               .Named(CachedListProjectsCommandName);

            this.Bind<ICommand>().To<ValidatableCommand>()
                .InSingletonScope()
                .Named(ListProjectsCommandName);

            this.Bind<ICommandsFactory>().ToFactory().InSingletonScope().Intercept().With<CommandExceptionHandlerInterceptor>();
            this.Bind<ICommand>().ToMethod(context =>
            {
                return context.Kernel.Get<ICommand>(context.Parameters.First().GetValue(context, null).ToString().ToLower());
            })
            .NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommandFromString(null));
        }
    }
}
