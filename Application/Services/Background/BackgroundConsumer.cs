using Application.Interfaces.Services.Utlities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Background
{
    public class BackgroundConsumer : BackgroundService
    {
        private readonly IkafkaConsumer _Consumer;
        public BackgroundConsumer(IkafkaConsumer Consumer)
        {
            _Consumer=Consumer;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
                await _Consumer.ConsumeMessagesAsync(stoppingToken);
            
          
        }

        public override void Dispose()
        {
          
            _Consumer.Dispose();
            base.Dispose();
        }
    }
}

