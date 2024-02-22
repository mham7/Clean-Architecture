using Application.Interfaces.Repos.DbConfiguration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.DbConfiguration
{
    public class DbConfiguration:IDbConfiguration
    {
        public string ConnectionString { get; private set; }
        public DbConfiguration(IConfiguration config) {

            ConnectionString = config.GetConnectionString("ContourDbConnection");
        
        }
    }
}
