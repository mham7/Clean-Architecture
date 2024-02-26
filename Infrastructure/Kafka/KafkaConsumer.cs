using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Application.Interfaces.Services.Utlities;
using MassTransit;
using Domain.Models;
using Serilog.Core;
using MassTransit.KafkaIntegration;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Kafka
{
    public class KafkaConsumer : IConsumer<Message>
    {
        private readonly ILogger<KafkaConsumer> _logger;

        public KafkaConsumer(ILogger<KafkaConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Message> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Received message: {message}");
        }
    }

}
