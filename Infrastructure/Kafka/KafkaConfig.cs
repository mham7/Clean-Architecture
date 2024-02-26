using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public class KafkaConfig
    {
        public static IConfiguration readConfig()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddIniFile("client.properties", false)
            .Build();
        }
    }
}
