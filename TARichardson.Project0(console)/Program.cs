﻿using System;
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
                        CurrentAccount = null
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

                return ui.ProcessState();
            }
            else {
                switch (ui.CurrentState)
                {
                    case State.CustomerPage:
                        return ui.ProcessState(app.CurrentCustomer);
                    case State.AccountPage:
                        return ui.ProcessState(app.CurrentCustomer.CurrentAccount);
                    case State.OpenAccountPage:
                        return ui.ProcessState();
                    case State.CloseAccountPage:
                        return true;
                    case State.SubmitOpen:
                        if (ui.GetOpen.Type == AccountType.TermAccount)
                        {
                            app.CurrentCustomer.OpenAccount(new TermAccount());
                        }
                        else if (ui.GetOpen.Type == AccountType.LoanAccount)
                        {
                            app.CurrentCustomer.OpenAccount(new LoanAccount());
                        }
                        else
                        {
                            app.CurrentCustomer.OpenAccount(new Account());
                        }
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
