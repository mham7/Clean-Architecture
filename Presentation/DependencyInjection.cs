using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace Presentation
{
    public static class DependencyInjection { 
            public static IServiceCollection AddPresentation(this IServiceCollection services)
            {
                
                return services;
            }
        }
    }
