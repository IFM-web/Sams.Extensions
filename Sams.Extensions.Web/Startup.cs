using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;


[assembly: OwinStartupAttribute(typeof(Sams.Extensions.Web.Startup))]
namespace Sams.Extensions.Web
{
    public partial class Startup
    {
    
        public void Configuration(IAppBuilder app)
        {
            // Increase request size (OWIN-specific workaround)
            app.Use(async (context, next) =>
            {
                context.Request.Body = new System.IO.MemoryStream(); // Allow larger requests
                await next.Invoke();
            });

            
        }





    }
}
