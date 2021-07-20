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

        public MainWindow()
        {
            InitializeComponent();

            reader = new TextReader();
        }

        private void LoadTextButtonClick(object sender, EventArgs args)
        {
            var text = reader.GetFileContents("Act 1/scene-1.txt");
            UneditedTextBox.Text = text;
            //MessageBox.Show(text);
        }
    }
}
