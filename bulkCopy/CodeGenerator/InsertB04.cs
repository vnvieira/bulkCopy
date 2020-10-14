using System;
using bulkCopy.Library;
using System.Runtime.InteropServices;

namespace bulkCopy.CodeGenerator
{

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("bulkCopy.InsereB04")]
    [ComVisible(true)]
    public class InsertB04 : InsertTable
    {
 
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


            _registros.Add(novoItem);
        }

    }


    public class ModelB04
    {
        public string USR_NOTE { get; set; }
        public string UKEY { get; set; }
        public DateTime TIMESTAMP { get; set; }
        public string STATUS { get; set; }
        public string SQLCMD { get; set; }
        public string MYCONTROL { get; set; }
        public string INTEGRATED { get; set; }
        public string CIA_UKEY { get; set; }
        public string A11_UKEY { get; set; }
        public string A36_CODE0 { get; set; }
        public string A56_UKEY { get; set; }
        public string B04_003_C { get; set; }
        public string B04_004_C { get; set; }
        public string B04_PAR { get; set; }
        public string B04_UKEYA { get; set; }
        public string B04_UKEYP { get; set; }
        public double B04_001_B { get; set; }
        public double B04_002_B { get; set; }
        public double B04_005_N { get; set; }
        public double B04_006_B { get; set; }

    }

}
