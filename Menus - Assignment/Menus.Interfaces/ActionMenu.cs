using System;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenu : MenuItem
    {
        private readonly string r_ExitMessage = "Press any Key To go back";
        private readonly IPreformable r_Action;

        public ActionMenu(string i_Title, Interfaces.IPreformable i_Action) : base(i_Title)
        {
            r_Action = i_Action;
        }

        public override void DisplayCurrentMenu()
        {
            Console.Clear();
            r_Action.PreformAction();
            System.Console.WriteLine(@"{0}{1}", Environment.NewLine, r_ExitMessage);
            System.Console.ReadLine();
            m_MenuParent.DisplayCurrentMenu();
        }
    }
}
