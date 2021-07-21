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
        private SceneManager sceneManager;
        CharacterProfileUI profileUi;
        CharacterDialogueUI dialogueUI;

        public MainWindow()
        {
            InitializeComponent();

            sceneManager = new SceneManager();
            profileUi = new CharacterProfileUI();
            dialogueUI = new CharacterDialogueUI();
        }

        private void LoadTextButtonClick(object sender, EventArgs args)
        {
            sceneManager.LoadScene();
            FileTextBox.Text = sceneManager.FullUneditedText;
        }

        private void GetNamesButtonClick(object sender, EventArgs args)
        {
            sceneManager.LoadNames();
            DialogueTextBox.Text = sceneManager.GetAllDialogueForPrinting();
            NamesTextBox.Text = sceneManager.GetAllNamesForPrinting();
        }

        private void PreviousCharacterButtonClick(object sender, EventArgs args)
        {
            sceneManager.PreviousSequence();
            SetProfileUI();
        }

        private void NextCharacterButtonClick(object sender, EventArgs args)
        {
            sceneManager.NextSequence();
            SetProfileUI();
        }

        private void SetProfileUI()
        {
            dialogueUI.SetDialogue(this, sceneManager.CurrentSequence.Dialogue);
            profileUi.SetProfile(this, sceneManager.CurrentSequence.Profile);
        }
    }
}
