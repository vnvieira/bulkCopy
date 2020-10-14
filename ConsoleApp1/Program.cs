using bulkCopy;
using System;
using System.Linq.Expressions;

namespace TesteApp
{
    class TesteApp
    {
        static void Main()
        {
            InsereB04 a = new InsereB04();

            for (int i = 0; i < 50000; i++)
            {
                a.AdicionarItem(new Guid().ToString().Substring(1, 20), "STAR_", 
                             "20150307GYQZ4R0QYXB4", "XXXXXXXX", "M43", 
                             null, " ", 10, 10, "C", "T", 1, 1, " ");
                Console.WriteLine(i);
            }

            // a.InformarConexao("Server=(local);Database=RFPMDL;Trusted_Connection=True;", 1)
            a.InformarConexao("Data Source=XE;User Id=STARSOFT;Password=STARSOFT;", 2);

            try
            { a.ExecutarInsert(); }

            catch
            {
                
            }
            finally { 
            }


            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
