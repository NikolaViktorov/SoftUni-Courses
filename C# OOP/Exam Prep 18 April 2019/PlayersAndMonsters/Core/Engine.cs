using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            ManagerController managerController = new ManagerController(
                new PlayerRepository(), new CardRepository());

            string[] command = Console.ReadLine().Split();
            while (command[0] != "Exit")
            {
                try
                {
                    if (command[0] == "AddPlayer")
                    {
                        string message = managerController.AddPlayer(command[1], command[2]);
                        Console.WriteLine(message);
                    }
                    else if (command[0] == "AddCard")
                    {
                        string message = managerController.AddCard(command[1], command[2]);
                        Console.WriteLine(message + "gei");
                    }
                    else if (command[0] == "AddPlayerCard")
                    {
                        string message = managerController.AddPlayerCard(command[1], command[2]);
                        Console.WriteLine(message);
                    }
                    else if (command[0] == "Fight")
                    {
                        string message = managerController.Fight(command[1], command[2]);
                        Console.WriteLine(message);
                    }
                    else if (command[0] == "Report")
                    {
                        string message = managerController.Report();
                        Console.WriteLine(message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                command = Console.ReadLine().Split();
            }
        }
    }
}
