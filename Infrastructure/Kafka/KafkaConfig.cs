using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using ServiceStack.Text;

namespace Infrastructure.Kafka
{      public class KafkaConfig
        {
            public required string BootstrapServers { get; set; }
            public required string ClientId { get; set; }
            public SecurityProtocol SecurityProtocol { get; set; }

        }

    
}
