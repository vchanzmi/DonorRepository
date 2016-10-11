using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoadDonorData.Startup))]
namespace LoadDonorData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
