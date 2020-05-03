using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class InterfacesBasedMenus
    {
        public void ExecuteInterfacesBasedMenus()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interface Based Menu");
            mainMenu.AddAnotherSubMenu(new Interfaces.MenuItem("Show Date/Time")); // Menu location on List is 0 in mainmenu
            mainMenu.AddAnotherSubMenu(new Interfaces.MenuItem("Version and Digits")); // Menu location on List is 1 in mainmenu

            // Date and time Insertion
            Interfaces.MenuItem ShowDateAndTimeMenu = mainMenu.GetSubMenuByIndex(0);
            ShowDateAndTimeMenu.AddAnotherSubMenu(new Interfaces.ActionMenu("Show Date", new Date())); // Menu location on List is 0 in ShowDateAndTimeMenu
            ShowDateAndTimeMenu.AddAnotherSubMenu(new Interfaces.ActionMenu("Show Time", new Time())); // Menu location on List is 1 in ShowDateAndTimeMenu

            // Version and Digits Insertion
            Interfaces.MenuItem showVersionAndDigitsMenu = mainMenu.GetSubMenuByIndex(1);

            showVersionAndDigitsMenu.AddAnotherSubMenu(new Interfaces.ActionMenu("Show Version", new Version())); // Menu location on List is 0 in ShowVersionAndDigitsMenu
            showVersionAndDigitsMenu.AddAnotherSubMenu(new Interfaces.ActionMenu("Count Spaces", new Digits())); // Menu location on List is 1 in ShowVersionAndDigitsMenu

            mainMenu.Show();
        }
    }
}
