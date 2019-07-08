using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Entities;
using Utility;
using System.IO;
using System.Xml.Serialization;


namespace TARichardson.Project0.console
{
    class Program
    {
        public static UI ui = new UI()
        {
            CurrentState = State.WelcomePage
        };
        public static App app = new App()
        {
            Run = true,
            CurrentCustomer = null
        };
        static public bool Update()
        {
            if (app.CurrentCustomer == null)
            {
                if (ui.CurrentState == State.SubmitRegisterPage)
                {
                    if (app.Register(new Customer()
                    {
                        CustomerID = 104,
                        FirstName = ui.GetRegister.FirstName,
                        LastName = ui.GetRegister.LastName,
                        PageMax = 10,
                        CurrentAccount = null,
                        Accounts = new List<IAccount>()
                    }))
                    {
                        Console.WriteLine("Customer created");
                        ui.CurrentState = State.CustomerPage;
                    }
                    else
                    {
                        Console.WriteLine("Customer failed to create");
                        ui.CurrentState = State.WelcomePage;

                    }
                }
                else if (ui.CurrentState == State.SubmitLoginPage)
                {
                    app.LogIn(ui.GetLogin.UserName, ui.GetLogin.Password);
                }
                ui.WriteSection();
                return ui.ProcessState();
            }
            else {
                switch (ui.CurrentState)
                {
                    case State.CustomerPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        return ui.ProcessState(app.CurrentCustomer);
                    case State.ListAccountPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        ui.ProcessInfo(app.CurrentCustomer.Accounts);
                        return ui.ProcessState();
                    case State.AccountPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        ui.ProcessInfo(app.CurrentCustomer.CurrentAccount);
                        return ui.ProcessState(app.CurrentCustomer.CurrentAccount);
                    case State.ListAccountTransactionPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        ui.ProcessInfo(app.CurrentCustomer.CurrentAccount);
                        ui.ProcessInfo(app.CurrentCustomer.CurrentAccount.Transactions);
                        return ui.ProcessState();
                    case State.WithDrawPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        ui.ProcessInfo(app.CurrentCustomer.CurrentAccount);
                        if (ui.ProcessWithDrawState(app.CurrentCustomer.CurrentAccount))
                        {
                            Console.WriteLine("Withdrawal complete");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Your account doesn't support overdrafts");
                            return true;

                        }
                    case State.DepositPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        ui.ProcessInfo(app.CurrentCustomer.CurrentAccount);
                        return ui.ProcessDepositState(app.CurrentCustomer.CurrentAccount);
                    case State.TransferPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        ui.ProcessInfo(app.CurrentCustomer.CurrentAccount);
                        int selectionTransfer = ui.SelectAccount("Transfer To", app.CurrentCustomer.Accounts, false, true, app.CurrentCustomer.CurrentAccount);
                        if (selectionTransfer  > -1)
                        {
                            return ui.ProcessTransferState(app.CurrentCustomer.CurrentAccount, app.CurrentCustomer.Accounts[selectionTransfer]);
                        }
                        return true;
                    case State.OpenAccountPage:
                        ui.WriteSection();
                        ui.ProcessInfo(app.CurrentCustomer);
                        return ui.ProcessState();
                    case State.CloseAccountPage:
                        int selectionClose = ui.SelectAccount("Close", app.CurrentCustomer.Accounts, false);
                        if (selectionClose > -1)
                        {
                            app.CurrentCustomer.CloseAccount(selectionClose);
                        }
                        return true;
                    case State.CloseCurrentAccountPage:
                        app.CurrentCustomer.CloseCurrentAccounts();
                        ui.CurrentState = State.CustomerPage;
                        return true;
                    case State.SelectAccountPage:
                        int selectionView = ui.SelectAccount("View", app.CurrentCustomer.Accounts);
                        if(selectionView > -1)
                        {
                            app.CurrentCustomer.MakeCurrentAccounts(selectionView);
                        }
                        return true;
                    case State.SubmitOpen:
                        DateTime CurrentDT = DateTime.Now;
                        switch (ui.GetOpen.Type)
                        { 
                            case AccountType.TermAccount:
                                app.CurrentCustomer.OpenAccount(new TermAccount() {
                                    Balances = ui.GetOpen.Balance,
                                    Type = ui.GetOpen.Type,
                                    AccountID = app.CurrentCustomer.Accounts.Count + 200,
                                    InterestRate = 10,
                                    StartingBalance = ui.GetOpen.Balance,
                                    AccountOpenDate = CurrentDT,
                                    BeginningStatment = CurrentDT,
                                    NextStatment = CurrentDT.AddDays(30),
                                    PageMax = 10,

                                    Transactions = new List<Transaction>() {
                                        new Transaction()
                                            {
                                                Type = TransactionType.OPN,
                                                TransactionID = 0,
                                                Date = CurrentDT,
                                                Log = $"{ui.GetOpen.Type} Account Open with balances of {ui.GetOpen.Balance}"
                                            }},
                                    Matrity = false
                                });

                                break;
                            case AccountType.LoanAccount:
                                app.CurrentCustomer.OpenAccount(new LoanAccount() {
                                    Balances = ui.GetOpen.Balance,
                                    Type = ui.GetOpen.Type,
                                    AccountID = app.CurrentCustomer.Accounts.Count + 200,
                                    InterestRate = 10,
                                    StartingBalance = ui.GetOpen.Balance,
                                    AccountOpenDate = CurrentDT,
                                    BeginningStatment = CurrentDT,
                                    NextStatment = CurrentDT.AddDays(30),
                                    PageMax = 10,
                                    Transactions = new List<Transaction>() {
                                        new Transaction()
                                            {
                                                Type = TransactionType.OPN,
                                                TransactionID = 0,
                                                Date = CurrentDT,
                                                Log = $"{ui.GetOpen.Type} Account Open with balances of {ui.GetOpen.Balance}"
                                            }},
                                });
                                break;
                            case AccountType.CheckingAccount:
                            app.CurrentCustomer.OpenAccount(new CheckingAccount() {
                                Balances = ui.GetOpen.Balance,
                                Type = ui.GetOpen.Type,
                                AccountID = app.CurrentCustomer.Accounts.Count + 200,
                                InterestRate = 10,
                                AccountOpenDate = CurrentDT,
                                BeginningStatment = CurrentDT,
                                NextStatment = CurrentDT.AddDays(30),
                                PageMax = 10,
                                Transactions = new List<Transaction>()  {
                                        new Transaction()
                                            {
                                                Type = TransactionType.OPN,
                                                TransactionID = 0,
                                                Date = CurrentDT,
                                                Log = $"{ui.GetOpen.Type} Account Open with balances of {ui.GetOpen.Balance}"
                                            }},
                            });
                            break;
                            case AccountType.BusinessAccount:
                                app.CurrentCustomer.OpenAccount(new BusinessAccount()
                                {
                                    Balances = ui.GetOpen.Balance,
                                    Type = ui.GetOpen.Type,
                                    AccountID = app.CurrentCustomer.Accounts.Count + 200,
                                    InterestRate = 10,
                                    AccountOpenDate = CurrentDT,
                                    BeginningStatment = CurrentDT,
                                    NextStatment = CurrentDT.AddDays(30),
                                    PageMax = 10,
                                    Transactions = new List<Transaction>()  {
                                        new Transaction()
                                            {
                                                Type = TransactionType.OPN,
                                                TransactionID = 0,
                                                Date = CurrentDT,
                                                Log = $"{ui.GetOpen.Type} Account Open with balances of {ui.GetOpen.Balance}"
                                            }},
                                });
                                break;
                            default:
                                ui.WriteSection();
                                Console.WriteLine("Error couldn't create a new Account.");
                                Console.WriteLine("Returning to Customer Page.");
                                ui.CurrentState = State.CustomerPage;
                                return true;
                        }
                        ui.CurrentState = State.AccountPage;
                        return true;
                    default:
                        return false;
                       
                }

            } 
        }
        static void Main(string[] args)
        {
        //    string filename = @".\..\..\..\DB\CustomersDB.xml";
        //    XmlRootAttribute xRoot = new XmlRootAttribute();
        //    xRoot.ElementName = "Customers";
        //    xRoot.IsNullable = true;

        //    XmlSerializer reader = new XmlSerializer(typeof(Customer),xRoot);
        //    FileStream file = new FileStream(filename, FileMode.Open);
        //    Customer customers = (Customer)reader.Deserialize(file);
        //    Console.WriteLine($"Customer First name {customers.FirstName}");

        //    file.Close();

           // Console.WriteLine($"{overview.Title} by {overview.Author}");

            while (app.Run)
            {

                app.Run = Update();
            }
        }

    }
}
