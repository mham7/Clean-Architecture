using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Kafka
{
    using Domain.Models;
    using MassTransit;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class KafkaMessageProducer
    {
        private readonly IBusControl _busControl;
        private readonly ITopicProducer<Message> _producer;

        public KafkaMessageProducer(IBusControl busControl, ITopicProducer<Message> producer)
        {
            _busControl = busControl ?? throw new ArgumentNullException(nameof(busControl));
            _producer = producer ?? throw new ArgumentNullException(nameof(producer));
        }

        public async Task StartProducingAsync()
        {
            await _busControl.StartAsync(new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token);

            try
            {
                do
                {
                    string value = await Task.Run(() =>
                    {
                        Console.WriteLine("Enter text (or quit to exit)");
                        Console.Write("> ");
                        return Console.ReadLine();
                    });

                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                    // Assuming KafkaMessage has a property named 'Text'
                    var kafkaMessage = value;
                    

                    await _producer.Produce(kafkaMessage);
                } while (true);
            }
            finally
            {
                await _busControl.StopAsync();
            }
        }
    }
}
