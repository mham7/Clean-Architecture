using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos.DbConfiguration
{
  public interface IDbConfiguration
    {
        string ConnectionString { get;}
    }
}
