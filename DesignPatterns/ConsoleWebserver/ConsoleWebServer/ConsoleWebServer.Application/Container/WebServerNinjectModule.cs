namespace ConsoleWebServer.Application.Container
{
    using System;
    using Ninject.Modules;
    using ConsoleWebServer.Framework.Contracts;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Application.Contracts;
    using ConsoleWebServer.Application.Controllers;
    using ConsoleWebServer.Application.Providers;
    using ConsoleWebServer.Framework.Handlers;
    using ConsoleWebServer.Framework.Providers;
    using ConsoleWebServer.Framework.ActionResults;
    using Ninject.Extensions.Interception.Infrastructure.Language;
    using ConsoleWebServer.Application.Interceptors;
    using Ninject.Extensions.Conventions;
    using System.IO;
    using System.Reflection;
    using Ninject;
    using Ninject.Extensions.Factory;

    public class WebServerNinjectModule : NinjectModule
    {
        public const string HeadHandlerName = "HeadHandler";
        public const string OptionsHandlerName = "OptionsHandler";
        public const string ProtocolVersionHandlerName = "ProtocolVersionHandler";
        public const string StaticFileHandlerName = "StaticFileHandler";

        public const string ContentActionName = "ContentActionResult";
        public const string JsonActionName = "JsonActionResult";
        public const string ActionWithoutCachingName = "ActionResultWithoutCaching";
        public const string ActionWithCorsName = "ActionResultWIthCors";

        public const string MessageReaderName = "MessageReader";

        public override void Load()
        {
            //this.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName
            //        (Assembly.GetExecutingAssembly().Location))
            //        .SelectAllClasses()
            //        .BindDefaultInterface();
            //});

            this.Bind<IWebServerConsole>().To<WebServerConsole>().InSingletonScope().Intercept().With<TestEnviromentInterceptor>();

            this.Bind<IHomeController>().To<HomeController>();
            this.Bind<IApiController>().To<ApiController>();

            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>().WhenInjectedInto<IWebServerConsole>();
            this.Bind<IReader>().To<MessageReader>().Named(MessageReaderName);

            this.Bind<IActionResult>().To<ContentActionResult>().Named(ContentActionName);
            this.Bind<IActionResult>().To<JsonActionResult>().Named(JsonActionName);
            this.Bind<IActionResult>().To<ActionResultWIthCors>().Named(ActionWithCorsName);
            this.Bind<IActionResult>().To<ActionResultWithoutCaching>().Named(ActionWithoutCachingName);

            this.Bind<IHandler>().To<HeadHandler>().InSingletonScope().Named(HeadHandlerName);
            this.Bind<IHandler>().To<OptionsHandler>().InSingletonScope().Named(OptionsHandlerName);
            this.Bind<IHandler>().To<ProtocolVersionHandler>().InSingletonScope().Named(ProtocolVersionHandlerName);
            this.Bind<IHandler>().To<StaticFileHandler>().InSingletonScope().Named(StaticFileHandlerName);
            this.Bind<IHandler>().ToMethod(ctx =>
            {
                var headHandler = ctx.Kernel.Get<IHandler>(HeadHandlerName);
                var optionsHandler = ctx.Kernel.Get<IHandler>(OptionsHandlerName);
                var protocolVersionHandler = ctx.Kernel.Get<IHandler>(ProtocolVersionHandlerName);
                var staticFileHandler = ctx.Kernel.Get<IHandler>(StaticFileHandlerName);

                headHandler.SetSuccessor(optionsHandler);
                optionsHandler.SetSuccessor(protocolVersionHandler);
                protocolVersionHandler.SetSuccessor(staticFileHandler);

                return headHandler;
            }).WhenInjectedInto<ResponseProvider>();

            this.Bind<IHttpRequest>().To<HttpRequest>();
            this.Bind<HttpResponse>().ToSelf();
            this.Bind<ActionDescriptor>().ToSelf();

            this.Bind<IReaderFactory>().ToFactory().InSingletonScope();
            this.Bind<IHttpRequestFactory>().ToFactory().InSingletonScope();
            this.Bind<IHttpResponseFactory>().ToFactory().InSingletonScope();
            this.Bind<IActionResultFactory>().ToFactory().InSingletonScope();

            this.Bind<IResponseProvider>().To<ResponseProvider>().Intercept().With<StopwatchInterceptor>();
            this.Bind<IRequestParser>().To<RequestParser>().Intercept().With<StopwatchInterceptor>();
        }
    }
}
