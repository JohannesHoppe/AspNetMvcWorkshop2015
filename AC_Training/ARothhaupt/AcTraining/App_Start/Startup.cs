
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AcTraining.Starttup))]
namespace AcTraining
{
    public class Starttup
    {
        public  void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
