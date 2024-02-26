using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Utlities
{
    public interface IKafkaProducer
    {
        Task ProduceMessageAsync(Message message);
    }
}
