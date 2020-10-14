using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using System.Linq.Expressions;

namespace bulkCopy
{
    public class BulkInsert
    {

        protected internal void InsertData<T>(List<T> list, string TableName, string ConnectionString, int dbType)
        {
            if (dbType == 1)
                InsertDataSql<T>(list, TableName, ConnectionString);
            else
                InsertDataOrcl<T>(list, TableName, ConnectionString);
        }

        protected internal void InsertDataSql<T>(List<T> list, string TableName, string ConnectionString)
        {
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(ConnectionString))
            {

                foreach (PropertyDescriptor prop in GetListroperties<T>())
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(prop.Name, prop.Name));

                bulkcopy.BulkCopyTimeout = 660;
                bulkcopy.DestinationTableName = TableName;
                bulkcopy.WriteToServer(ConvertToDataTable(list));
            }
        }

        protected internal void InsertDataOrcl<T>(List<T> list, string TableName, string ConnectionString)
        {

            using (OracleBulkCopy bulkcopy = new OracleBulkCopy(ConnectionString))
            {

                foreach (PropertyDescriptor prop in GetListroperties<T>())
                    bulkcopy.ColumnMappings.Add(new OracleBulkCopyColumnMapping(prop.Name, prop.Name));

                bulkcopy.BulkCopyTimeout = 660;
                bulkcopy.DestinationTableName = TableName;
                try
                {
                    bulkcopy.WriteToServer(ConvertToDataTable(list));
                }
                catch 
                { 
                    
                }
                    
            }
        }
        protected DataTable ConvertToDataTable<T>(IList<T> data)
        {
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in GetListroperties<T>())
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in GetListroperties<T>())
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        PropertyDescriptorCollection GetListroperties<T>()
        {
            return TypeDescriptor.GetProperties(typeof(T));
        }


    }
}



