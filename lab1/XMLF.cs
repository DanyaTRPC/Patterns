using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class XMLF:F
    {
        private readonly List<CreateXML> createXMLs;
        public XMLF(List<CreateXML> createXMLs)
        {
            this.createXMLs = createXMLs;
        }
        public override IFile GetLevel()
        {
            XmlFile xmlFile = new XmlFile(createXMLs);
            {

            };
            return xmlFile;

        }
    }
}
