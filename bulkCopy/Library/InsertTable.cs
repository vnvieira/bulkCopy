
using System.Collections.Generic;


namespace bulkCopy.Library
{

    
    public class InsertTable
    {

        protected internal List<object> _registros;
        protected internal int _dbType;
        protected internal string _conexao;
        protected internal string _table;


        public InsertTable()
        {
            _registros = new List<object>();
        }

        public void InformarConexao(string Conexao, int dbType, string table)
        {
            _conexao = Conexao;
            _dbType = dbType;
            _table = table;
        }

        //public virtual void AdicionarItem(object Item) 
        //{
        //    _registros.Add(Item);    
        //}

        public void LimparLista()
        {
            _registros.Clear();
        }
        
        public void ExecutarInsert()
        {
            if (_registros.Count == 0)
                return;

            BulkInsert bulk = BulkFactory.Factory(_dbType, _conexao);
            bulk.InsertData<object>(_registros, _table);

            LimparLista();

        }

    }
}
