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
        public OpenAccount GetOpen
        {
            get => open;
            set{ open = value;}
        }

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
            Console.WriteLine("\t(O)pen to open new Account" +
                "\n\t(C)lose to close a Account" +
                "\n\t(V)iew a Account" +
                "\n\t(L)ist to list all Accounts" +
                "\n\t(U)pdate all Accounts" +
                "\n\t(E)xit to exit");
            Console.WriteLine("Enter choice: ");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "open":
                case "o":
                    CurrentState = State.OpenAccountPage;
                    Console.WriteLine("To Opening Account Page . . . ");
                    return true;
                case "close":
                case "c":
                    CurrentState = State.CloseAccountPage;
                    Console.WriteLine("To Closing Account Page . . . ");
                    return true;
                case "view":
                case "v":
                    CurrentState = State.SelectAccountPage;
                    Console.WriteLine("To Select Account Page . . . ");
                    return true;
                case "list":
                case "l":
                    CurrentState = State.ListAccountPage;
                    Console.WriteLine("To Account List Page . . . ");
                    return true;
                case "update":
                case "u":
                    CurrentState = State.UpdateAccountPage;
                    Console.WriteLine("To Update Account Page . . . ");
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
        public bool ProcessState(IAccount account)
        {
            Console.WriteLine("\t(B)ack to Customer" +
                "\n\t(W)ithdraw from account" +
                "\n\t(D)eposit to account" +
                "\n\t(T)ransfer funds to another Account" +
                "\n\t(V)iew transactions" +
                "\n\t(G)et loan from bank" +
                "\n\t(C)lose to close the Account" +
                "\n\t(E)xit to exit");
            Console.WriteLine("Enter choice: ");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "back":
                case "b":
                    CurrentState = State.CustomerPage;
                    Console.WriteLine("To Customer Account Page . . . ");
                    return true;
                case "withdraw":
                case "w":
                    CurrentState = State.WithDrawPage;
                    Console.WriteLine("To WithDraw Page . . .");
                    return true;
                case "desposit":
                case "d":
                    CurrentState = State.DepositPage;
                    Console.WriteLine("To Deposit Page . . .");
                    return true;
                case "transfer":
                case "t":
                    CurrentState = State.TransferPage;
                    return true;
                case "view":
                case "v":
                    CurrentState = State.ListAccountTransactionPage;
                    return true;
                case "get":
                case "g":
                    open = new OpenAccount(1, AccountType.LoanAccount, 0);
                    CurrentState = State.OpenAccountPage;
                    return true;
                case "close":
                case "c":
                    CurrentState = State.CloseCurrentAccountPage;
                    Console.WriteLine("To Closing Account Page . . . ");
                    return true;
                case "list":
                case "l":
                    CurrentState = State.ListAccountPage;
                    Console.WriteLine("To Account List Page . . . ");
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
                case State.SubmitOpen:
                    open = new OpenAccount(0, AccountType.CheckingAccount, 0);
                    break;
                case State.WelcomePage:
                    return ProcessWelcomeState();
                case State.ListAccountPage:
                    Console.WriteLine("Press enter/return key to continue back to the Customer Page . .");
                    Console.ReadLine();
                    CurrentState = State.CustomerPage;
                    return true;
                case State.ListAccountTransactionPage:
                    Console.WriteLine("Press enter/return key to continue back to the Account Page . .");
                    Console.ReadLine();
                    CurrentState = State.AccountPage;
                    return true;
                default:
                    return true;
            }
            return true;
        }
        public bool ProcessInfo(Customer customer)
        {
            Console.WriteLine($"Customer ID: {customer.CustomerID}");
            Console.WriteLine($"Account Holder: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Number of Accounts: {customer.Accounts.Count()}");
            return true;
        }
        public bool ProcessInfo(IAccount account)
        {
            Console.WriteLine($"\tAccount ID: {account.AccountID}");
            Console.WriteLine($"\tAccount Type: {account.Type} Balance: {account.Balances}");
            Console.WriteLine($"\tNumber of Transactions: {account.Transactions.Count()}");
            return true;
        }
        public bool ProcessInfo(List<IAccount> accounts)
        {
            WriteSection();
            Console.WriteLine("Account List:");
            foreach (IAccount account in accounts)
            {
                ProcessInfo(account);
            }
            return true;
        }
        public bool ProcessInfo(Transaction transaction)
        {
            Console.WriteLine($"\t\tTransaction ID: {transaction.TransactionID}");
            Console.WriteLine($"\t\tTransaction Type: {transaction.Type}");
            Console.WriteLine($"\t\tLog: {transaction.Log}");
            return true;
        }
        public bool ProcessInfo(List<Transaction> transactions)
        {
            WriteSection();
            Console.WriteLine("Transaction List:");
            WriteSection();
            foreach (Transaction transaction in transactions)
            {
                ProcessInfo(transaction);
            }
            return true;
        }
        public void WriteSection()
        {
            Console.WriteLine("________________________________________");
        }
        public int SelectAccount(string str, List<IAccount> accounts, bool toView = true, bool forTransfer = false, IAccount currentAccount = null)
        {
            WriteSection();
            Console.WriteLine($"Choose a account from list to {str}:");
            int index = 0;
            foreach (IAccount account in accounts)
            {
                string Option = forTransfer && account == currentAccount
                    ? "\tAccount you are transfering from: "
                    : $"\tOption ({index}): ";

                Console.WriteLine(Option);
                ProcessInfo(account);
                index++;
            }
            Console.WriteLine("\tChoice (c)ancel to cancel.");
            string tempStr = Console.ReadLine();
            if (tempStr.ToLower() == "c" || tempStr.ToLower() == "cancel")
            {
                CurrentState = State.CustomerPage;
                return -1;
            }
            try
            {
                int tempNum = Int32.Parse(tempStr);
                if (tempNum > -1 && tempNum < accounts.Count())
                {
                    if(currentAccount != null && currentAccount != accounts[tempNum] || currentAccount == null)
                    {
                        CurrentState = toView ? State.AccountPage : State.ListAccountPage;
                        return tempNum;
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                        Console.WriteLine("can't transfer to same account");
                        return -1;
                    }


                }
                else
                {
                    Console.WriteLine("invalid input");
                    return -1;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input");
                return -1;
            }
        }

        public bool ProcessWithDrawState(IAccount account)
        {
            int sum = HowMuch("withdraw");
            return sum > 0 ? account.WithDraw(sum) : true;
        }
        public bool ProcessDepositState(IAccount account)
        {
            int sum = HowMuch("deposit");
            return sum > 0 ? account.Deposit(sum) : true;
        }
        public bool ProcessTransferState(IAccount fromAccount, IAccount toAccount)
        {
            int sum = HowMuch("Transfer");
            if( sum > 0 ? fromAccount.WithDraw(sum) : false)
            {
                if (toAccount.Deposit(sum))
                {
                    return true;
                }
                else
                {
                    fromAccount.Deposit(sum);
                }
            }
            return true;
        }
        public int HowMuch(string str)
        {
            WriteSection();
            Console.WriteLine($"\tHow much do you want to ({str}) or choose (c)ancel to cancel:");
            string tempStr = Console.ReadLine();
            if (tempStr.ToLower() == "c" || tempStr.ToLower() == "cancel")
            {
                CurrentState = State.AccountPage;
                return -1;
            }
            try
            {
                int tempNum = Int32.Parse(tempStr);
                 if (tempNum > 0)
                {
                    CurrentState = State.ListAccountPage;
                    return tempNum;
                }
                else
                {
                    Console.WriteLine("invalid input");
                    return -1;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input");
                return -1;
            }
        }

    }
}
