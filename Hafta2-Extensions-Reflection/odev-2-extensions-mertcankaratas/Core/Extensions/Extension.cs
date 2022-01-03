
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CollectiveExtension
    {
        public static string Logger(this string text)
        {
            return "logglandı";
        }


        
        public static string DolarToTurkishLira(this float dolar)
        {
            return "Dolar today exchange rate 13,40 " + dolar + " equals to Turkish lira: " + dolar * 13.40;
        }

        public static string ReflactionType(Type type)
        {
            return type.GetType().ToString();
        }

        public static string MethodInfoAssemblyLocation(Type type)
        {
            return type.GetTypeInfo().Assembly.Location;

        }

        public static string GetMethods(Type type, string methodsName = null)
        {
            var methods = type.GetMethods();

            foreach (var info in methods)
            {
                methodsName += info.ToString()+"\n";
            }

            return methodsName;
        }
    }
}
