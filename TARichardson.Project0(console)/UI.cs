using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utility;

namespace TARichardson.Project0.console
{
    public class UI
    {

        private Register register = new Register();
        private Login login = new Login();
        private OpenAccount open = new OpenAccount();

        public bool ReadyToSubmit = false;
        public State CurrentState { get; set; }
        public Register GetRegister { get => register; }
        public Login GetLogin { get => login; }

        public IRegLog ProcessRegLogState(IRegLog reglog)
        {
            reglog.Print();
            switch (reglog.Step)
            {
                case 0:
                    reglog.InputOne();
                    break;
                case 1:
                    reglog.InputTwo();
                    break;
                default:
                    reglog.ResetStep();
                    ReadyToSubmit = true;
                    CurrentState = reglog.Submit();
                    break;
            }
            return reglog;
        }
        public bool ProcessWelcomeState()
        {
            Console.WriteLine("(R)egister to Register, (L)ogin, (E)xit to exit");
            Console.WriteLine("Enter choice: ");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "register":
                case "r":
                    CurrentState = State.RegisterPage;
                    Console.WriteLine("To Register Page . . . ");
                    return true;

                case "login":
                case "l":
                    CurrentState = State.LogInPage;
                    Console.WriteLine("To Log-in Page . . . ");
                    return true;
                case "exit":
                case "e":
                    CurrentState = State.LogOutPage;
                    Console.WriteLine("exiting . . . ");
                    return false;
                default:
                    Console.WriteLine("Your input was invalid.");
                    return true;
            }
        }

        public bool ProcessState(Customer customer)
        {
            Console.WriteLine("(O)pen to open new Account, (C)lose to close a Account, (L)ist to list all Accounts, (E)xit to exit");
            Console.WriteLine("Enter choice: ");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "open":
                case "o":
                    CurrentState = State.RegisterPage;
                    Console.WriteLine("To Opening Account Page . . . ");
                    return true;
                case "close":
                case "c":
                    CurrentState = State.LogInPage;
                    Console.WriteLine("To Closing Account Page . . . ");
                    return true;
                case "list":
                case "l":
                    CurrentState = State.LogOutPage;
                    Console.WriteLine("To Account List Page . . . ");
                    return false;
                case "exit":
                case "e":
                    CurrentState = State.LogOutPage;
                    Console.WriteLine("exiting . . . ");
                    return false;
                default:
                    Console.WriteLine("Your input was invalid.");
                    return true;
            }
        }
        public bool ProcessState(Account account)
        {
            return true;
        }

        public bool ProcessState()
        {
            switch (CurrentState)
            {
                case State.RegisterPage:
                    register = (Register)ProcessRegLogState(register);
                    break;
                case State.LogInPage:
                    login = (Login)ProcessRegLogState(login);
                    break;
                case State.OpenAccountPage:
                    open = (OpenAccount)ProcessRegLogState(open);
                    break;
                case State.WelcomePage:
                    return ProcessWelcomeState();
                default:
                    return true;
            }
            return true;
        }

    }
}
