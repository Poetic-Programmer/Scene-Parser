using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene_Parser
{
    class DialogueSequence
    {
        public readonly CharacterProfile Profile;
        public readonly CharacterDialogue Dialogue;

        public DialogueSequence(CharacterProfile profile, CharacterDialogue dialogue)
        {
            Profile = profile;
            Dialogue = dialogue;
        }

        public string GetCharacterName()
        {
            return Profile.Name;
        }
        public string GetDialogueText()
        {
            return Dialogue.Text;
        }
    }
}