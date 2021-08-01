using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Logic.Interfaces;
using Tourism.Logic.Services;

namespace Tourism.Logic
{
    public class LogicServicesContainer
    {
        public static void Register(IServiceCollection services)
        {
#if DEBUG
            services.AddScoped<IMailService, LocalMailService>();
#else
            services.AddScoped<IMailService, CloudMailService>();
#endif
        }
    }
}
