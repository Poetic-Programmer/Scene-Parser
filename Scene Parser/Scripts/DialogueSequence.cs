using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene_Parser
{
    class DialogueSequence
    {
        public readonly string SpeakerName;
        public readonly string Dialogue;

        public DialogueSequence(string speakerName, string dialogue)
        {
            SpeakerName = speakerName;
            Dialogue = dialogue;
        }
    }
}
