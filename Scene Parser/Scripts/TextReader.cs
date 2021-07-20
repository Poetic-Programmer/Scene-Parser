using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scene_Parser
{
    class TextReader
    {
        private readonly string location = "/Text/Acts/";

        public TextReader()
        {

        }

        public string GetFileContents(string filename)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;

            var text = File.ReadAllLines(projectDirectory + location + filename);
            StringBuilder builder = new StringBuilder();
            
            foreach(string s in text)
            {
                builder.Append(s);
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
