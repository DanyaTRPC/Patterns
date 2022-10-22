using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class XmlFile:IFile
    {
        List<CreateXML> createXMLs;
        public XmlFile(List<CreateXML> createXMLs)
        {
            this.createXMLs = createXMLs;
        }


        public string[] CreateFile()
        {
            string[] files = new string[createXMLs.Count];
            for (int i = 0; i < files.Length; i++)
            {
                files[i]=$" {createXMLs[i].id} {createXMLs[i].name}";
            }
            return files;
        }
    }
}
