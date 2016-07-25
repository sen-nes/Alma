using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlmaTest.Startup))]
namespace AlmaTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
