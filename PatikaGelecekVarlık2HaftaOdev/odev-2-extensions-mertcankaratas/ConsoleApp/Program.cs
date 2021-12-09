
using Core.Extensions;
using DataAccess.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. extension para biçimi formatlama
            float Dolar = 13;
            Console.WriteLine(Dolar.DolarToTurkishLira());
            Console.WriteLine(Core.Extensions.CollectiveExtension.DolarToTurkishLira(15));
            
            //2. extension reflaction type
            Console.WriteLine(Core.Extensions.CollectiveExtension.ReflactionType(typeof(UserDal)));
            //2. extension Method info assembly karsılığı
             Console.WriteLine(Core.Extensions.CollectiveExtension.MethodInfoAssemblyLocation(typeof(UserDal)));
            //2. userdal'daki methodların isimlerini gösteren extension
            Console.WriteLine(Core.Extensions.CollectiveExtension.GetMethods(typeof(UserDal)));
 
            

            Console.ReadLine();
           
        }


        
    }
}
