using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Persistence.EF.Utils
{
    public class TicketingContextFactory:IDbContextFactory<TicketingDbContext>
    {
        public TicketingDbContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var connection=new SqlConnection(connectionString);
            return new TicketingDbContext(connection,true);
        }
    }
}
