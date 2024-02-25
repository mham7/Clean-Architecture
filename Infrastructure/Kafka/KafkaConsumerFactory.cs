using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Kafka
{
    public class KafkaConsumerFactory
    {
        private readonly KafkaConfig _config;

        public KafkaConsumerFactory(KafkaConfig config)
        {
            _config = config;
        }

        public IConsumer<string, string> CreateConsumer(string topic)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "my-consumer-group", 
                BootstrapServers = _config.BootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest, 
                SecurityProtocol = _config.SecurityProtocol
            };

            return new ConsumerBuilder<string, string>(consumerConfig).Build();
        }
    }

}
