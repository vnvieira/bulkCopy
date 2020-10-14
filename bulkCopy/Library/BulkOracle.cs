using System.Collections.Generic;
using System.ComponentModel;
using Oracle.DataAccess.Client;


namespace bulkCopy.Library
{
    class BulkOracle: BulkInsert
    {

        public BulkOracle(string ConnectionString) : base(ConnectionString) { }
        protected internal override void InsertData<T>(List<T> list, string TableName)
        {

            using (OracleBulkCopy bulkcopy = new OracleBulkCopy(_connectionString))
            {

                foreach (PropertyDescriptor prop in GetListroperties<T>())
                    bulkcopy.ColumnMappings.Add(new OracleBulkCopyColumnMapping(prop.Name, prop.Name));

                bulkcopy.DestinationTableName = TableName;
                bulkcopy.WriteToServer(ConvertToDataTable(list));
            }

        }
    }

}

