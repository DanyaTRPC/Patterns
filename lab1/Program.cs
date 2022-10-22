using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateXML X1 = new CreateXML("21554","FDGFDGD");
            CreateXML X2 = new CreateXML("21554", "FDGFDGD");

            List<CreateXML> createXMLs = new List<CreateXML>();
            createXMLs.Add(X1);
            createXMLs.Add(X2);


            Console.WriteLine("Select a type of file");
            Console.WriteLine("> 1-JSON");
            Console.WriteLine("> 2-XML");

            int levelType = Int32.Parse(Console.ReadLine());

            F f = null;
            if (levelType == 1)
            {
                f = new JSONF("21.09.2024", "Description", "url");
            }
            else if (levelType == 2)
            {
                f = new XMLF(createXMLs);
            }

            IFile file = f.GetLevel();
            string[] a= file.CreateFile();

            for (int i = 0; i < a.Length; i++)
            {
               Console.WriteLine(a[i]);
            }
            Console.ReadLine();
        }

    }
}
