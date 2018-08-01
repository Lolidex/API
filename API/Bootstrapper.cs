using Nancy;

namespace API
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.AfterRequest.AddItemToEndOfPipeline((context) =>
            {
                context.Response.WithHeader("Access-Control-Allow-Origin", "*");
            });
        }
    }
}
