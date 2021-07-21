using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene_Parser
{
    class CharacterDialogueUI
    {
        public CharacterDialogueUI()
        {

        }

        public void SetDialogue(MainWindow window, CharacterDialogue dialogue)
        {
            window.IndividualDialogueTextBlock.Text = dialogue.Text;
        }
    }
}
