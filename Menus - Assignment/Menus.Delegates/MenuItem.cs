using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        protected MenuItem m_MenuParent;
        protected string m_ExitMessage;
        private readonly List<MenuItem> r_SubMenusList;
        private readonly string r_Title;
        private readonly int r_ExitCommand = 0;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
            m_ExitMessage = "Back";
            r_SubMenusList = new List<MenuItem>();
        }

        public string Title
        {
            get { return r_Title; }
        }

        public List<MenuItem> SubMenus// return an exception if list is empty
        {
            get
            {
                checksIfSubMenusListIsEmpty();
                return r_SubMenusList;
            }
        }

        private MenuItem MenuParent
        {
            set { m_MenuParent = value; }
        }

        public void AddAnotherSubMenu(MenuItem i_SubMenu)
        {
            i_SubMenu.MenuParent = this;
            r_SubMenusList.Add(i_SubMenu);
        }

        public MenuItem GetSubMenuByIndex(int i_Index)
        {
            checksIfSubMenusListIsEmpty();
            if (i_Index < 0 || i_Index > r_SubMenusList.Count)
            {
                throw new Exception("Index in the sub menus list is out of bound");
            }

            return r_SubMenusList[i_Index];
        }

        public virtual void DisplayCurrentMenu()
        {
            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(r_Title);
            int menuNum = 1;

            foreach (MenuItem subMenu in r_SubMenusList)
            {
                stringBuilder.AppendFormat(@"{0}{1}. {2} ", Environment.NewLine, menuNum, subMenu.r_Title);
                menuNum++;
            }

            stringBuilder.AppendFormat(@"{0}{1}. {2}", Environment.NewLine, r_ExitCommand, m_ExitMessage);
            System.Console.WriteLine(stringBuilder.ToString());
            int userChoice = getUserChoice();
            selectUserChoice(userChoice);
        }

        private int getUserChoice()
        {
            int userChoice;
            string userAnswer;
            userAnswer = System.Console.ReadLine();

            if (!int.TryParse(userAnswer, out userChoice))
            {
                System.Console.WriteLine("Invalid input, Please try again");
                userChoice = getUserChoice();
            }
            else if (userChoice < 0 || userChoice > r_SubMenusList.Count)
            {
                System.Console.WriteLine("choice is out of range, Please try again");
                userChoice = getUserChoice();
            }

            return userChoice;
        }

        private void selectUserChoice(int i_UserChoice)
        { 
            if(i_UserChoice != r_ExitCommand)
            {
                r_SubMenusList[i_UserChoice - 1].DisplayCurrentMenu(); // User choices are ordered in the list
            }
            else
            {
                if (m_MenuParent != null)
                {
                    m_MenuParent.DisplayCurrentMenu();
                }
            }
        }

        private void checksIfSubMenusListIsEmpty()
        {
            if(r_SubMenusList.Count == 0)
            {
                throw new Exception("There are no sub menus");
            }
        }
    }
}
