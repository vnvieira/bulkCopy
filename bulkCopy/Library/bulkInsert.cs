using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using Oracle.DataAccess.Client;


namespace bulkCopy
{
    public class BulkInsert
    {
        protected internal string _connectionString;
        protected internal int _timeOut = 600;

        public BulkInsert(string ConnextionString)
        {
            _connectionString = ConnextionString;
        }
        protected internal virtual void InsertData<T>(List<T> list, string TableName)
        {
        }

        protected  DataTable ConvertToDataTable<T>(IList<T> data)
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

        protected  PropertyDescriptorCollection GetListroperties<T>()
        {
            return TypeDescriptor.GetProperties(typeof(T));
        }


    }
}



