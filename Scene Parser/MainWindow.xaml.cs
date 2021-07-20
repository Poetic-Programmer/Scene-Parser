using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scene_Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextReader reader;
        List<string> names;
        string text = "";
        public MainWindow()
        {
            InitializeComponent();

            reader = new TextReader();
            names = new List<string>();
        }

        private void LoadTextButtonClick(object sender, EventArgs args)
        {
            text = reader.GetFileContents("Act 1/scene-1.txt");
            UneditedTextBox.Text = text;
        }

        private void GetNamesButtonClick(object sender, EventArgs args)
        {
            string[] seperators = new[] {"<sequence>"};
            var sequences = text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in sequences)
            {
                ParseSequence(s);
            }
            NamesTextBox.Text = BuildStringList(names);
        }

        private void ParseSequence(string sequence)
        {
            int index = sequence.IndexOf("<character>") + "<character>".Length;
            int endIndex = sequence.IndexOf("</character>");
            int length = endIndex - index;
            string name = sequence.Substring(index, length);

            names.Add(name);
        }

        private string BuildStringList(List<string> lines)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string s in lines)
            {
                var edit = s.Trim();
                builder.Append(edit);
                builder.Append("\n");
                Console.WriteLine(string.Format("Length of line: {0}", edit.Length));
            }
            return builder.ToString();
        }
    }
}
