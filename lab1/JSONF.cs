using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class JSONF:F
    {
        public string Data;
        public string Description;
        public string URL;

        public JSONF(string Data, string Description, string URL)
        {
            this.Data = Data;
            this.Description = Description;
            this.URL = URL;
        }
        public override IFile GetLevel()
        {
            CreateJSON createJSON = new CreateJSON(Data, Description, URL)
            {

            };
            return createJSON;
        }
    }
}
