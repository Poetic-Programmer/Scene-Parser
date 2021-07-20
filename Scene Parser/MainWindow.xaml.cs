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
        List<DialogueSequence> sequence;
        string text = "";
        public MainWindow()
        {
            InitializeComponent();

            reader = new TextReader();
            sequence = new List<DialogueSequence>();
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
                sequence.Add(ParseSequence(s));
            }

            ParsedTextBox.Text = GetAllDialogueForPrinting();
            NamesTextBox.Text = GetAllNamesForPrinting();
        }

        private string GetAllNamesForPrinting()
        {
            StringBuilder builder = new StringBuilder();
            foreach(DialogueSequence dialogue in sequence)
            {
                builder.Append(dialogue.SpeakerName);
                builder.Append("\n");
            }
            return builder.ToString();
        }

        private string GetAllDialogueForPrinting()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DialogueSequence dialogue in sequence)
            {
                builder.Append(dialogue.Dialogue);
                builder.Append("\n");
            }
            return builder.ToString();
        }

        private DialogueSequence ParseSequence(string text)
        {
            string name = GetTextBetween(text, "<character>", "</character>");
            string dialogue = GetTextBetween(text, "<dialogue>", "</dialogue>").Trim();

            return new DialogueSequence(name, dialogue);
        }

        private string GetTextBetween(string text, string startKey, string endKey)
        {
            int startIndex = text.IndexOf(startKey) + startKey.Length;
            int endIndex = text.IndexOf(endKey);
            int length = endIndex - startIndex;
            return text.Substring(startIndex, length);
        }
    }
}
