using System;
using Ninject.Modules;
using Academy.Core.Contracts;
using Ninject.Extensions.Conventions;
using Academy.Core;
using System.IO;
using System.Reflection;
using Academy.Core.Providers;
using Academy.Core.Factories;
using Academy.Framework.Core.Factories;
using Ninject.Extensions.Factory;
using Academy.Commands.Contracts;
using Ninject;
using System.Linq;
using Academy.Commands.Adding;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Framework.Models.Contracts;
using Academy.Framework.Core.Contracts;
using Academy.Framework.Commands.Adding.CourseForms;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Academy.Interceptors;
using Academy.Configuration;
using Academy.Models.Contracts;
using Academy.Models.Utils.LectureResources;

namespace Academy.Container
{
    public class AcademyModule : NinjectModule
    {
        public const string EngineName = "Engine";

        // course forms
        private const string OnlineCourseFormName = "OnlineCourseForm";
        private const string OnsiteCourseFormName = "OnsiteCourseForm";

        // commands
        // adding
        public const string AddStudentToCourseCommandName = "AddStudentToCourse";
        public const string AddStudentToSeasonCommandName = "AddStudentToSeason";
        public const string AddTrainerToCourseCommandName = "AddTrainerToSeason";

        // creating
        public const string CreateCourseCommandName = "CreateCourse";
        public const string CreateCourseResultCommandName = "CreateCourseResult";
        public const string CreateLectureCommandName = "CreateLecture";
        public const string CreateSeasonCommandName = "CreateSeason";
        public const string CreateStudentCommandName = "CreateStudent";
        public const string CreateTrainerCommandName = "CreateTrainer";

        // listing
        public const string ListCoursesInSeasonCommand = "ListCoursesInSeason";
        public const string ListUsersCommand = "ListUsers";
        public const string ListUsersInSeasonCommand = "ListUsersInSeason";

        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named(EngineName);
            this.Bind<IAcademyModel>().To<Framework.Models.Academy>().InSingletonScope();

            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();

            // course forms
            this.Bind<ICourseForm>().To<OnlineCourseForm>().InSingletonScope().Named(OnlineCourseFormName);
            this.Bind<ICourseForm>().To<OnsiteCourseForm>().InSingletonScope().Named(OnsiteCourseFormName);

            // commands
            // adding
            this.Bind<ICommand>().To<AddStudentToCourseCommand>().InSingletonScope().Named(AddStudentToCourseCommandName);
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().InSingletonScope().Named(AddStudentToSeasonCommandName);
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().InSingletonScope().Named(AddTrainerToCourseCommandName);

            // creating
            this.Bind<ICommand>().To<CreateCourseCommand>().InSingletonScope().Named(CreateCourseCommandName);
            this.Bind<ICommand>().To<CreateCourseResultCommand>().InSingletonScope().Named(CreateCourseResultCommandName);
            this.Bind<ICommand>().To<CreateLectureCommand>().InSingletonScope().Named(CreateLectureCommandName);
            this.Bind<ICommand>().To<CreateSeasonCommand>().InSingletonScope().Named(CreateSeasonCommandName);
            this.Bind<ICommand>().To<CreateStudentCommand>().InSingletonScope().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTrainerCommand>().InSingletonScope().Named(CreateTrainerCommandName);

            // listing
            var listCourseInSeasonBinding = this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().InSingletonScope().Named(ListCoursesInSeasonCommand);
            var listUsersBinding = this.Bind<ICommand>().To<ListUsersCommand>().InSingletonScope().Named(ListUsersCommand);
            var listUsersInSeasonBinding = this.Bind<ICommand>().To<ListUsersInSeasonCommand>().InSingletonScope().Named(ListUsersInSeasonCommand);

            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommand>().ToMethod(context =>
            {
                return context.Kernel.Get<ICommand>(context.Parameters.ToList().First().GetValue(context, null).ToString());
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            this.Bind<ILectureResourceFactory>().ToFactory().InSingletonScope();
            this.Bind<ILectureResource>().ToMethod(context =>
            {
                var date = DateTimeProvider.Provider.GetDateTime();
                var parameters = context.Parameters.Select(x => x.ToString()).ToList();

                var type = parameters[0];
                var name = parameters[1];
                var url = parameters[2];

                switch (type)
                {
                    case "video": return new VideoResource(name, url, date);
                    case "presentation": return new PresentationResource(name, url);
                    case "demo": return new DemoResource(name, url);
                    case "homework": return new HomeworkResource(name, url, date.AddDays(7));
                    default: throw new ArgumentException("Invalid lecture resource type");
                }

            }).NamedLikeFactoryMethod((ILectureResourceFactory resourceFactory) => resourceFactory.GetLectureResource(null, null, null));

            // interceptions
            if (Kernel.Get<IConfigurationsManager>().IsListingCommandsEnvironment()) // random condition
            {
                listCourseInSeasonBinding.Intercept().With<LoggingInterceptor>();
                listUsersBinding.Intercept().With<LoggingInterceptor>();
                listUsersInSeasonBinding.Intercept().With<LoggingInterceptor>();
            }
        }
    }
}
