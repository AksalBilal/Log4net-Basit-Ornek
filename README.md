# Log4net-Basit-Ornek
Projelerde görülen error, info, fatal,warn gibi bildirimlerin sistem tarafından kayıt alınmasına yönelik C# Console kullanılarak yapılmış bir örnektir.

                                                   ÖRNEĞİN UYGULANMASI
          
1-) İlk olarak bir c# console uygulaması açalım
2-) Uygulamamıza Manage Nuget Packages kullanarak log4net modülünü yükleyelim.
3-) Properties klasörü altındaki AssemblyInfo sınıfı açıp "[assembly: log4net.Config.XmlConfigurator]" yazısını ekleyelim.

![assemblyinfo](https://user-images.githubusercontent.com/46024317/64182698-4e317080-ce71-11e9-9cd9-628d603ce6c5.PNG)

Ekledikten sonra AssemblInfo sınıfı yukarıdaki gibi olmalıdır.
4-) Solution Explorer penceresinden App.config sınıfına girip configuration taglari arasında bulunan startup taglarini silmeden altına veya üstüne alttaki kod blogunu yapıştıralım.
 
 <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>
 <appSettings>
        <add key="log4net.Config" value="log4.config"/>
        <add key="log4net.Config.Watch" value="True"/>
        <add key="log4net.Internal.Debug" value="False"/>
    </appSettings>
  <log4net>
    <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="log.txt" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="250KB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
      </layout>
    </appender>
    <root>
      <level value="ALL" />
      <appender-ref ref="RollingFileAppender" />
    </root>
  </log4net>

Ekledikten sonra App.config sınıfımız Aşşağıdaki gibi olmalıdır.

![appConfig](https://user-images.githubusercontent.com/46024317/64183026-db74c500-ce71-11e9-8f99-c8847078c07d.PNG)

5-) Gerekli ayarlamaları yaptık artık kod yazalım. Program sınıfına girelim ve aşşağıdaki kod satırları ile log nesnemizi tanımlayalım;

private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

6-) Main fonksiyonun içine alttaki kod satırlarını yazıp programı çalıştıralım.

log.Info("Info logging");//İnfo loglanması
            log.Fatal("Info Fatal"); //Fatal loglanması   
            log.Warn("Info Warning");//Warning loglanması   
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
            
 Console çıktısı aşşağıdaki resimdeki gibiyse loglama işlemimiz başarıyla tamamlandı demektir.
 
 ![program](https://user-images.githubusercontent.com/46024317/64183625-d5cbaf00-ce72-11e9-9c89-98257f90f1e5.PNG)
 
 Peki bu log kayıtlarımız nerede tutuluyor. Loglarımız olduğu txt dosyası default olarak projemizin bulunduğu klasörün bin/debug klasörlerinin altında log.txt adlı dosyada tutuluyor.
 
 Bunu değiştirmek için 4. adımda App.config sınıfına eklediğimiz kodlarda bulunan <file value="log.txt" /> koduna istediğimiz dosya yolunu belirtebiliriz.
 
 Son olarak txt dosyamızdan bir fotoğraf gösterelim;
 
 ![log](https://user-images.githubusercontent.com/46024317/64184104-a23d5480-ce73-11e9-972c-672364dbdf66.PNG)

 

