using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net

{
    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
           //proje içindeki bin/debug klasörü altında log.txt dosyasına kayıt edilmektedir.
            Console.WriteLine("Writing to \"log.txt\" in the same directory as the .exe file.\n");
            log.Info("Info logging");//İnfo loglanması
            log.Fatal("Info Fatal");    
            log.Warn("Info Warning");
            try
            {
                throw new Exception("Exception!");
            }
            catch (Exception e)
            {
                log.Error("This is my error", e);//Error loglanması
            }
            Console.WriteLine("[any key to exit]");
            Console.ReadKey();
        }
    }
}
