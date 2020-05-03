using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class DelegatesBasedMenu
    {
        public void ExecuteDelegatesBasedMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Delegates Based Menu");
            mainMenu.AddAnotherSubMenu(new Delegates.MenuItem("Show Date/Time")); // Menu location on List is 0 in mainmenu
            mainMenu.AddAnotherSubMenu(new Delegates.MenuItem("Version and Digits")); // Menu location on List is 1 in mainmenu

            // Date and time Insertion
            Delegates.MenuItem ShowDateAndTimeMenu = mainMenu.GetSubMenuByIndex(0);
            ShowDateAndTimeMenu.AddAnotherSubMenu(new Delegates.ActionMenu(new Date().PreformAction, "Show Date"));
            ShowDateAndTimeMenu.AddAnotherSubMenu(new Delegates.ActionMenu(new Time().PreformAction, "Show Time"));

            // Version and Digits Insertion
            Delegates.MenuItem ShowVersionAndDigits = mainMenu.GetSubMenuByIndex(1);
            ShowVersionAndDigits.AddAnotherSubMenu(new Delegates.ActionMenu(new Version().PreformAction, "Show Version"));
            ShowVersionAndDigits.AddAnotherSubMenu(new Delegates.ActionMenu(new Digits().PreformAction, "Count Spaces"));

            mainMenu.Show();
        }
    }
}
