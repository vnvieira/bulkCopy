
using System.Collections.Generic;


namespace bulkCopy.Library
{

    
    public class InsertTable
    {

        protected internal List<object> Registros;
        protected internal int _dbType;
        protected internal string _conexao;
        protected internal string _table;

  
        public void InformarConexao(string Conexao, int dbType, string table)
        {
            _conexao = Conexao;
            _dbType = dbType;
            _table = table;
        }

        public void AdicionarItem(object Item) 
        {
            Registros.Add(Item);    
        }

        public void LimparLista()
        {
            Registros.Clear();
        }
        
        public void ExecutarInsert()
        {
            if (Registros.Count == 0)
                return;

            BulkInsert bulk = BulkFactory.Factory(_dbType, _conexao);
            bulk.InsertData<object>(Registros, _table);

            LimparLista();

        }

    }
}
