using System;

namespace Extension
{
     public static class Extension
    {
        public static string Logger(this string text)
        {
            return  "logglandı";
        }


        public static string DolarToTurkishLira(this float dolar)
        {
            return "Dolar today exchange rate 13,40 " + dolar + " equals to Turkish lira: " +dolar * 13.40;
        }

    }
}
