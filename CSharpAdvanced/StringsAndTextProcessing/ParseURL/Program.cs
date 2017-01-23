using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParseURL
{
    class Program
    {
        static void Main()
        {

            string URL = Console.ReadLine();
            string protocol = string.Empty;
            string server = string.Empty;
            string resource = string.Empty;

            if (URL.IndexOf("://") != -1)
            {
                protocol = URL.Substring(0, URL.IndexOf("://"));
                URL = URL.Substring(URL.IndexOf("://") + 3);
            }

            if (URL.IndexOf('/') != -1)
            {
                resource = URL.Substring(URL.IndexOf('/'));
                URL = URL.Substring(0, URL.IndexOf('/'));
            }

            server = URL;

            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", resource);

        }
    }
}
