using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene_Parser
{
    class CharacterProfile
    {
        public readonly string Name;

        public CharacterProfile(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            CharacterProfile p = (CharacterProfile)obj;
            return Name == p.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
