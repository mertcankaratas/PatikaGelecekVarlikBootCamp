using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{/// <summary>
/// Extension methodlar 
/// Burada
/// belirlenen ücrete kdv eklendiğindeki fiyatını
/// Verilen Type'ın türünü
/// Verilen Type'ın bulunduğu konumu 
/// Verilen Type'ta bulunan methodları
/// 
/// </summary>
    public static class CollectiveExtension
    {
       
        public static string PriceWithKdv(this float price)
        {
            return "Price: " + price + " price with KDV Turkish lira: " + price * 1.18;
        }

        public static string ReflactionType(this Type type)
        {
            return type.GetType().ToString();
        }

        public static string MethodInfoAssemblyLocation(this Type type)
        {
            return type.GetTypeInfo().Assembly.Location;

        }

        public static string GetMethods(this Type type, string methodsName = null)
        {
            var methods = type.GetMethods();

            foreach (var info in methods)
            {
                methodsName += info.ToString() + "\n";
            }

            return methodsName;
        }
    }
}
