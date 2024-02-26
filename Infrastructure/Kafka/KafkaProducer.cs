using System;
using System.IO;
using Application.Interfaces.Services.Utlities;
using Confluent.Kafka;
using Domain.Models;
using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Kafka
{
    public class KafkaProducer : IKafkaProducer,IDisposable
    {
        private IConfiguration configuration;
        private const string topic = "u_chats";
        private IProducer<string, string> kafkaProducer;

        public KafkaProducer()
        {
           

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "pkc-4r087.us-west2.gcp.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl, 
                SaslMechanism = SaslMechanism.Plain, 
                SaslUsername = "SPO4ZCHZEOBPAUQZ",
                SaslPassword = "hRGaYYEkA+4xGJSgedx7V3syNo9UDfjYI/QswR3i4lZoqZ+R4bUo5fdBI2R/kpV5",
            };

            kafkaProducer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        public async Task ProduceMessageAsync(Message message)
        {
            var messageKey = Guid.NewGuid().ToString();


            var messageToSend = new Message<string, string>
            {
                Key = messageKey,
                Value = JsonConvert.SerializeObject(message),
                Timestamp = Timestamp.Default,
            };

            try
            {
                var deliveryReport = await kafkaProducer.ProduceAsync(topic, messageToSend);
                Console.WriteLine($"Message delivered to {deliveryReport.TopicPartitionOffset}");
            }
            catch (ProduceException<string, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }

        public void Dispose()
        {
            kafkaProducer?.Dispose();
        }

       
    }
}
