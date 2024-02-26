using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces.Services.Utlities
{
    public interface IkafkaConsumer : IDisposable
    {
        event EventHandler<string> MessageConsumed;

        Task ConsumeMessagesAsync(CancellationToken stoppingToken);

    }
}
