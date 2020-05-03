using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_Title) : base(i_Title)
        {
            m_ExitMessage = "Exit";
            m_MenuParent = null;
        }

        public void Show()
        {
            DisplayCurrentMenu();
        }
    }
}
