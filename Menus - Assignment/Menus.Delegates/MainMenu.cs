namespace Ex04.Menus.Delegates
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
