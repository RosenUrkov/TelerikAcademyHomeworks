using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public const string CreateStudentCommandName = "CreateStudent";
        public const string CreateTeacherCommandName = "CreateTeacher";
        public const string RemoveStudentCommandName = "RemoveStudent";
        public const string RemoveTeacherCommandName = "RemoveTeacher";
        public const string StudentListMarksCommandName = "StudentListMarks";
        public const string TeacherAddMarkCommandName = "TeacherAddMark";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<ISchoolSystem>().To<School>().InSingletonScope();

            this.Bind<ICommand>().To<CreateStudentCommand>().InSingletonScope().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTeacherCommand>().InSingletonScope().Named(CreateTeacherCommandName);
            this.Bind<ICommand>().To<RemoveStudentCommand>().InSingletonScope().Named(RemoveStudentCommandName);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().InSingletonScope().Named(RemoveTeacherCommandName);
            this.Bind<ICommand>().To<StudentListMarksCommand>().InSingletonScope().Named(StudentListMarksCommandName);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().InSingletonScope().Named(TeacherAddMarkCommandName);

            this.Bind<IParser>().To<CommandParserProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();

            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();
            var studentFactoryBinding = this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            var markFactoryBinding = this.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            var commandFactoryBinding = this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommand>().ToMethod(context =>
            {
                return context.Kernel.Get<ICommand>(context.Parameters.ToList().First().GetValue(context,null).ToString());

            }).NamedLikeFactoryMethod((ICommandFactory factory) => factory.GetCommand(null));

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                studentFactoryBinding.Intercept().With<TimeMeasurementInterceptor>();
                markFactoryBinding.Intercept().With<TimeMeasurementInterceptor>();
                commandFactoryBinding.Intercept().With<TimeMeasurementInterceptor>();
            }
        }
    }
}