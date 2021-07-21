using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene_Parser
{
    class SceneManager
    {
        public string FullUneditedText { get; private set; }

        TextReader reader;
        List<DialogueSequence> sequence;
        int characterIndex;
        int sequenceIndex;

        List<CharacterProfile> profile;

        public SceneManager()
        {
            reader = new TextReader();
            sequence = new List<DialogueSequence>();
            characterIndex = 0;
            sequenceIndex = 0;

            profile = new List<CharacterProfile>();
        }

        public DialogueSequence CurrentSequence
        {
            get { return sequence[sequenceIndex]; }
            private set { }
        }
        public void LoadScene()
        {
            FullUneditedText = reader.GetFileContents("Act 1/scene-1.txt");
        }

        public void LoadNames()
        {
            string[] seperators = new[] { "<sequence>" };
            var sequences = FullUneditedText.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in sequences)
            {
                sequence.Add(ParseSequence(s));
            }
        }

        public void NextSequence()
        {
            if (characterIndex < profile.Count - 1)
                characterIndex++;

            if (sequenceIndex < sequence.Count - 1)
                sequenceIndex++;
        }

        public void PreviousSequence()
        {
            if (characterIndex > 0)
                characterIndex--;

            if (sequenceIndex > 0)
                sequenceIndex--;
        }
            
        private DialogueSequence ParseSequence(string text)
        {
            string name = GetTextBetween(text, "<character>", "</character>");
            string dialogueText = GetTextBetween(text, "<dialogue>", "</dialogue>").Trim();

            var characterProfile = new CharacterProfile(name);
            var dialogue = new CharacterDialogue(dialogueText);

            if (!IsCharacter(characterProfile))
            {
                profile.Add(characterProfile);
            }

            return new DialogueSequence(characterProfile, dialogue);
        }

        private bool IsCharacter(CharacterProfile characterProfile)
        {
            bool isThere = false;
            foreach (CharacterProfile p in profile)
            {
                if (p.Equals(characterProfile))
                {
                    isThere = true;
                }
            }
            return isThere;
        }
        private string GetTextBetween(string text, string startKey, string endKey)
        {
            int startIndex = text.IndexOf(startKey) + startKey.Length;
            int endIndex = text.IndexOf(endKey);
            int length = endIndex - startIndex;
            return text.Substring(startIndex, length);
        }
        public string GetAllNamesForPrinting()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DialogueSequence dialogue in sequence)
            {
                builder.Append(dialogue.GetCharacterName());
                builder.Append("\n");

            }
            return builder.ToString();
        }

        public string GetAllDialogueForPrinting()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DialogueSequence dialogue in sequence)
            {
                builder.Append(dialogue.GetDialogueText());
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
