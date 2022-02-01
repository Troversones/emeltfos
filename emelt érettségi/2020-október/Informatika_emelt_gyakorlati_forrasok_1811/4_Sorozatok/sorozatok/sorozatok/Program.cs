using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sorozatok
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("lista.txt");
            string nev, ido, evadresz; int perc, megnezte;
            int ismert = 0; int egy = 0; int nulla = 0; double osszperc = 0;
            
            for (int i = 0; i < file.Length; i+=5)
            {
                if (file[i] == "NI")
                {
                    ido = file[i];
                }
                else
                {
                    ido = DateTime.Parse(file[i]).ToString("yyyy.MM.dd.");
                    ismert++;
                }

                nev = file[i+1];
                evadresz = file[i+2];
                perc = int.Parse(file[i+3]);
                megnezte = int.Parse(file[i+4]);

                if (megnezte == 1)
                {
                    osszperc = osszperc + perc;
                }

                if (megnezte == 0)
                {
                    nulla++;
                }
                else if(megnezte == 1)
                {
                    egy++;
                }
            }
            double osszeg = nulla + egy;
            double asd = egy / osszeg;
            double vegleges = Math.Round(asd * 100, 2);
            double ora = Math.Round(osszperc / 60,2);
            double nap = Math.Round(ora / 24,2);

            Console.WriteLine("ismert epizódok száma: {0} db",ismert);
            Console.WriteLine("A látott epizódok százaléka: {0} %",vegleges);
            Console.WriteLine("{0} percet, {1} órát és {2} napot töltött a nézéssel",osszperc,ora,nap);
            Console.WriteLine("Adjon meg egy dátumot");
            string datum = Console.ReadLine();
            DateTime xd = DateTime.Parse(datum);

            string[] file2 = File.ReadAllLines("lista.txt");
            for (int i = 0; i < file2.Length; i += 5)
            {
                nev = file2[i + 1];
                evadresz = file2[i + 2];
                perc = int.Parse(file2[i + 3]);
                megnezte = int.Parse(file2[i + 4]);
                if (megnezte == 1 || file[i] == "NI")
                {

                }
                else
                {
                    
                    if (xd >= DateTime.Parse(file2[i]))
                    {
                        ido = DateTime.Parse(file2[i]).ToString("yyyy.MM.dd");
                        Console.WriteLine(" {0}       {1}", evadresz,nev);
                    }
                }
                
            }

            Console.ReadKey();
        }
    }
    
}
