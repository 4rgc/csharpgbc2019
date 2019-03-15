//Rafed Fareed 101205956
//Tuan Hai Phung 101170570
//Andrii Bohdan 101171640

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.Open("testdata.txt", FileMode.Open);
            using (StreamReader sr = new StreamReader(fs))
            {
                string ans = sr.ReadLine();
                Console.WriteLine(ans);
            }
        }
    }
}
