using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(B2C_WebForms.Startup))]

namespace B2C_WebForms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            ConfigureAuth(app);
        }
    }
}
