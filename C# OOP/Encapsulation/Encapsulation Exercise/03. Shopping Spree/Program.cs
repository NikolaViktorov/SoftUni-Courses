using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(new char[] { ' ', ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsArgs = Console.ReadLine()
                .Split(new char[] { ' ', ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < peopleArgs.Length; i += 2)
            {
                try
                {
                    Person curPerson = new Person(peopleArgs[i], decimal.Parse(peopleArgs[i + 1]));
                    people.Add(curPerson);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            for (int i = 0; i < productsArgs.Length; i+= 2)
            {
                try
                {
                    Product curProduct = new Product(productsArgs[i], decimal.Parse(productsArgs[i + 1]));
                    products.Add(curProduct);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "END")
            {
                Person person = people.Where(p => p.Name == command[0]).FirstOrDefault();
                Product product = products.Where(p => p.Name == command[1]).FirstOrDefault();

                people.Where(p => p == person).FirstOrDefault().BuyProduct(products.Where(p => p == product).FirstOrDefault());

                command = Console.ReadLine()
                .Split();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
