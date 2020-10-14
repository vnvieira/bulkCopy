using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace bulkCopy
{

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("bulkCopy.InsereB04")]
    [ComVisible(true)]
    public class InsereB04 :ModelB04
    {
        protected List<ModelB04> Registros;
        protected string _conexao;
        protected int _dbType;

        public  InsereB04()
        {

            Registros = new List<ModelB04>();
        }


        public void InformarConexao(string Conexao, int dbType)
        {
            _conexao = Conexao;
            _dbType = dbType;
        }


        public void AdicionarItem(string _UKEY, string _CIA_UKEY, 
                                    string _A11_UKEY, string _A56_UKEY,
                                    string _B04_PAR, string _B04_UKEYA,
                                    string _B04_UKEYP, double _B04_001_B,
                                    double _B04_002_B, string _B04_003_C,
                                    string _B04_004_C, int _B04_005_N,
                                    double _B04_006_B, string _A36_CODE0)
        {
            ModelB04 novoItem = new ModelB04();

            novoItem.UKEY = _UKEY;
            novoItem.CIA_UKEY = _CIA_UKEY;
            novoItem.A11_UKEY = _A11_UKEY;
            novoItem.A56_UKEY = _A56_UKEY;
            novoItem.B04_PAR = _B04_PAR;
            novoItem.B04_UKEYA = _B04_UKEYA;
            novoItem.B04_UKEYP = _B04_UKEYP;
            novoItem.B04_001_B = _B04_001_B;
            novoItem.B04_002_B = _B04_002_B;
            novoItem.B04_003_C = _B04_003_C;
            novoItem.B04_004_C = _B04_004_C;
            novoItem.B04_005_N = _B04_005_N;
            novoItem.B04_006_B = _B04_006_B;
            novoItem.A36_CODE0 = _A36_CODE0;
            novoItem.TIMESTAMP = DateTime.Now;
            novoItem.SQLCMD = " ";
            novoItem.STATUS = " ";
            novoItem.MYCONTROL = "1";
            novoItem.INTEGRATED = " ";
         

            Registros.Add(novoItem);
        }

        public void ExecutarInsert()
        {
            if (Registros.Count == 0)
                return;
            
            BulkInsert bulk = new BulkInsert();
            bulk.InsertData<ModelB04>(Registros, "B04", _conexao, _dbType);
        }
    }


}
