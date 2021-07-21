using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Scene_Parser
{
    class CharacterProfileUI
    {
        public CharacterProfileUI()
        {

        }

        public void SetProfile(MainWindow window, CharacterProfile profile)
        {
            window.NameLabel.Content = profile.Name;
        }
    }
}
