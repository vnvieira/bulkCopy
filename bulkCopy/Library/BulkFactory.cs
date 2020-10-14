using bulkCopy.Library;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkCopy
{
    public static class BulkFactory
    {
      
        public static BulkInsert Factory(int dbType, string ConnectionString)
        {

            BulkInsert bCopy;
            if (dbType == 1)
                bCopy = new BulkSqlServer(ConnectionString);
            else
                bCopy = new BulkOracle(ConnectionString);

            return bCopy;

        }
    
    }

}
