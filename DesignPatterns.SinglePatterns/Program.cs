using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SinglePatterns
{
  /*
    Singleton Desenini Ne Zaman Tercih Etmeliyim

     1.Sadece bir sınıfın örneği olduğu durumlarda
     2.Bu örneğe kontrollü erişimin sağlanması durumunda
     3. Daha sonraki geliştirme aşamalarında birden fazşa örenğe ihtiyacımız odluğunda
     4.Kontrol , başka bir mekanizma değil, somutlaştırılmış sınıfta yerleştirilemlidir
        */
    class Program
    {
        static void Main(string[] args)
        {
            var systemManager = SystemManager.CreateSingletonObject();
            systemManager.Save();

        }
    }
    class SystemManager
    {
        private static SystemManager _systemManager; //field

        public SystemManager() //Amaç dış erişime kapatmak
        {
            
        }

        //Aşağıda singleton örneğini oluşturacak static nesne yaratıyoruz
        public static SystemManager CreateSingletonObject()
        {
            //Bu methodun içerisinde şunu kontrol ettik. Eğer system mager nesnesi daha önceden varsa, çağrıldığında da bdaha önceden oluşturulmuş nesneyi vereceğim, yoksa da oluşturup öyle göndereceğiz.
            if (_systemManager == null)
            {
                _systemManager = new SystemManager();
            }

            return _systemManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved...!");
            Console.ReadKey();
        }
    }

}
