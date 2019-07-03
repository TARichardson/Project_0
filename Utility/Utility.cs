using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public enum State
    {
        WelcomePage,
        RegisterPage,
        LogInPage,
        CustomerPage,
        AccountPage,
        LogOutPage,
        SubmitRegisterPage,
        SubmitLoginPage,
        SubmitOpen,
        SubmitClose,
        OpenAccountPage,
        ListAccountPage,
        CloseCurrentAccountPage,
        CloseAccountPage
    };
    public enum AccountType
    {
        CheckingAccount,
        LoanAccount,
        TermAccount,
        BusinessAccount
    };

    public interface IRegLog
    {
        int Step { get; set; }

        void InputOne();
        void InputTwo();
        void ResetStep();

        void Print();
        State Submit();
    }
    public struct Register : IRegLog
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Step { get; set; }
        public Register(int step = 0)
        {
            FirstName = "";
            LastName = "";
            Step = step;
        }

        public void InputOne()
        {
            Console.WriteLine("Enter your First Name:");
            FirstName = Console.ReadLine();
            Step += 1;
        }
        public void InputTwo()
        {
            Console.WriteLine("Enter your Last Name:");
            LastName = Console.ReadLine();
            Step += 1;
        }
        public void ResetStep()
        {
            Step = 0;
        }

        public void Print()
        {
            Console.WriteLine($"First Name: {FirstName} Last Name: {LastName}");

        }
        public State Submit()
        {
            return State.SubmitRegisterPage;
        }

    };
    public struct Login : IRegLog
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Step { get; set; }
        public Login(int step = 0)
        {
            UserName = "";
            Password = "";
            Step = step;
        }

        public void InputOne()
        {
            Console.WriteLine("Enter your User Name:");
            UserName = Console.ReadLine();
            Step += 1;
        }
        public void InputTwo()
        {
            Console.WriteLine("Enter your Password:");
            Password = Console.ReadLine();
            Step += 1;
        }
        public void ResetStep()
        {
            Step = 0;
        }
        public void Print()
        {
            Console.WriteLine($"User Name: {UserName} Password: {Password}");

        }
        public State Submit()
        {
            return State.SubmitLoginPage;
        }
    };
    public struct OpenAccount : IRegLog
    {
        public float Balance { get; set; }
        public AccountType Type { get; set; }
        public int Step { get; set; }
        public OpenAccount(int step = 0, AccountType type = AccountType.CheckingAccount)
        {
            Balance = 0;
            Type = type;
            Step = step;
        }

        public void InputOne()
        {
            Console.WriteLine("Enter your Account Type");
            Console.WriteLine("(0) CheckingAccount\n (1)LoanAccount\n (2)TermAccount\n (3)BusinessAccount");
            int tempNum = Int32.Parse(Console.ReadLine());
            if (tempNum > -1 && tempNum < 4)
            {
                Type = (AccountType)Enum.Parse(typeof(AccountType), tempNum.ToString(), true);
                Step += 1;
            }
            else
            {
                Console.WriteLine("invalid input");

            }
        }
        public void InputTwo()
        {
            Console.WriteLine("Enter your Starting Balance:");
            Balance = float.Parse(Console.ReadLine());
            Step += 1;
        }
        public void ResetStep()
        {
            Step = 0;
        }

        public void Print()
        {
            Console.WriteLine($"Account Type: {Type} Starting Balance: {Balance}");

        }
        public State Submit()
        {
           return State.SubmitOpen;
        }
    }

}
