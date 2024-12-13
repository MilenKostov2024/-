using System;
using System.Collections.Generic;

namespace BankConsoleApp
{
    class Program
    {
        static List<Client> clients = new List<Client>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Банкова система ===");
                Console.WriteLine("1. Създай нов клиент");
                Console.WriteLine("2. Вход за съществуващ клиент");
                Console.WriteLine("3. Изход");
                Console.Write("Изберете опция: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateClient();
                        break;
                    case "2":
                        LoginClient();
                        break;
                    case "3":
                        Console.WriteLine("Довиждане!");
                        return;
                    default:
                        Console.WriteLine("Невалиден избор. Опитайте отново.");
                        break;
                }
            }

            static void CreateClient()
            {
                Console.Write("Въведете име: ");
                string name = Console.ReadLine();

                Console.Write("Въведете ЕГН: ");
                string idNumber = Console.ReadLine();

                Client newClient = new Client(name, idNumber);
                clients.Add(newClient);

                Console.WriteLine($"Клиентът {name} е успешно създаден със сметка {newClient.Account.AccountNumber}.");
            }

            static void LoginClient()
            {
                Console.Write("Въведете ЕГН: ");
                string idNumber = Console.ReadLine();

                Client client = clients.Find(c => c.IdNumber == idNumber);

                if (client == null)
                {
                    Console.WriteLine("Клиент с това ЕГН не е намерен.");
                    return;
                }

                ManageAccount(client);
            }

            static void ManageAccount(Client client)
            {
                while (true)
                {
                    Console.WriteLine($"\n=== Управление на сметка за {client.Name} ===");
                    Console.WriteLine("1. Провери салдо");
                    Console.WriteLine("2. Депозирай средства");
                    Console.WriteLine("3. Тегли средства");
                    Console.WriteLine("4. История на транзакциите");
                    Console.WriteLine("5. Изход");
                    Console.Write("Изберете опция: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Текущо салдо: {client.Account.Balance} лв.");
                            break;
                        case "2":
                            Console.Write("Въведете сума за депозит: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                client.Account.Deposit(depositAmount);
                                Console.WriteLine($"Успешно депозирани {depositAmount} лв.");
                            }
                            else
                            {
                                Console.WriteLine("Невалидна сума.");
                            }
                            break;
                        case "3":
                            Console.Write("Въведете сума за теглене: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                try
                                {
                                    client.Account.Withdraw(withdrawAmount);
                                    Console.WriteLine($"Успешно изтеглени {withdrawAmount} лв.");
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Невалидна сума.");
                            }
                            break;
                        case "4":
                            Console.WriteLine("История на транзакциите:");
                            foreach (var transaction in client.Account.Transactions)
                            {
                                Console.WriteLine(transaction);
                            }
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Невалиден избор. Опитайте отново.");
                            break;                     
                    }
                }
            }
        }
    }
}
