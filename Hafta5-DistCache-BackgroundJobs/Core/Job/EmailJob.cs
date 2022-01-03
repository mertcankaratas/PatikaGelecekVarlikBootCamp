using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Job
{
   public static class EmailJob
    {/// <summary>
    /// email işinin yazıldığı yer.
    /// </summary>
    /// <param name="to"></param>
        public static void SendMail(string to)
        {
            Console.WriteLine($"{to} Aramıza hoş geldiniz ");
        }
    }
}
