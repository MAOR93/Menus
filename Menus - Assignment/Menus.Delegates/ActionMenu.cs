using System;

namespace Ex04.Menus.Delegates
{
    // $G$ CSS-021 (-3) Delegate name should end with the extension of "EventHandler".
    public delegate void MethodCall();

    public class ActionMenu : MenuItem
    {
        // $G$ CSS-021 (-3) Event name is like a class (should be in the form of CamelCase).
        public MethodCall m_MethodCaller;
       private readonly string r_ExitMessage = "Press any Key To go back";

        public ActionMenu(MethodCall i_Method, string i_Title) : base(i_Title)
        {
            m_MethodCaller = i_Method;
        }

        public override void DisplayCurrentMenu()
        {
            Console.Clear();
            DoMethodCall();
            System.Console.WriteLine(@"{0}{1}", Environment.NewLine, r_ExitMessage);
            System.Console.ReadLine();
            m_MenuParent.DisplayCurrentMenu();
        }

        // $G$ CSS-013 (-3) Bad variable name (should be in the form of: i_CamelCase).
        public void AddMethodCall(MethodCall method)
        {
            m_MethodCaller += method;
        }

        // $G$ CSS-013 (-3) Bad variable name (should be in the form of: i_CamelCase).
        public void RemoveMethodCall(MethodCall method)
        {
            m_MethodCaller += method;
        }

        private void DoMethodCall()
        {
            if(m_MethodCaller != null)
            {
                m_MethodCaller.Invoke();
            }
        }
    }
}
