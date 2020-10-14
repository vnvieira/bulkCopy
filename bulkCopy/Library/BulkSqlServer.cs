using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace bulkCopy.Library
{
    class BulkSqlServer : BulkInsert
    {

        public BulkSqlServer(string ConnectionString) : base(ConnectionString) { }

        protected internal override void InsertData<T>(List<T> list, string TableName)
        {
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(_connectionString))
            {
                foreach (PropertyDescriptor prop in GetListroperties<T>())
                bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(prop.Name, prop.Name));

                bulkcopy.DestinationTableName = TableName;
                bulkcopy.WriteToServer(ConvertToDataTable(list));
            }
        }


    }
}
