using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CreateJSON : IFile
    {
        public string Data;
        public string Description;
        public string URL; 

        public CreateJSON(string Data, string Description, string URL)
        {
            this.Data = Data;
            this.Description = Description;
            this.URL = URL;
        }

        public string[] CreateFile()
        {
            string[] files = new string[3];
            for (int i = 0; i < files.Length; i++)
            {
                files[0] = $"{Data}";
                files[1] = $"{Description}";
                files[2] = $"{URL}";

            }
            return files;
        }

    }
}
