using _03._Wild_Farm.Animals;
using _03._Wild_Farm.Animals.Mammal.Feline;
using _03._Wild_Farm.Animals.Mammal;
using System;
using _03._Wild_Farm.Animals.Birds;
using System.Collections.Generic;
using _03._Wild_Farm.Food;

namespace _03._Wild_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            int line = 0;
            string[] tokens = Console.ReadLine()
                .Split();
            Animal curAnimal = null;
            string animalType = "";
            while (tokens[0] != "End")
            {
               
                if (line % 2 == 0)
                {
                    string type = tokens[0];
                    animalType = type;
                    switch (type)
                    {
                        case "Tiger":
                            curAnimal = new Tiger(tokens[4], tokens[3],
                                tokens[1], double.Parse(tokens[2]));
                            break;
                        case "Cat":
                            curAnimal = new Cat(tokens[4], tokens[3],
                                tokens[1], double.Parse(tokens[2]));
                            break;
                        case "Dog":
                            curAnimal = new Dog(tokens[3],
                                tokens[1], double.Parse(tokens[2]));
                            break;
                        case "Mouse":
                            curAnimal = new Mouse(tokens[3],
                                tokens[1], double.Parse(tokens[2]));
                            break;
                        case "Hen":
                            curAnimal = new Hen(double.Parse(tokens[3]),
                               tokens[1], double.Parse(tokens[2]));
                            break;
                        case "Owl":
                            curAnimal = new Owl(double.Parse(tokens[3]),
                               tokens[1], double.Parse(tokens[2]));
                            break;
                    }
                }
                else
                {
                    Food.Food food = null;
                    string foodType = tokens[0];
                    switch (foodType)
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(tokens[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(tokens[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(tokens[1]));
                            break;
                        case "Seeds":
                            food = new Seed(int.Parse(tokens[1]));
                            break;
                    }
                    curAnimal.AskForFood();
                    if (animalType == "Mouse")
                    {
                        if (foodType != "Vegetable" && foodType != "Fruit")
                        {
                            Console.WriteLine($"Mouse does not eat {foodType}!");
                        }
                        else
                        {
                            curAnimal.Weight += 0.1 * food.Quantity;
                            curAnimal.FoodEaten += food.Quantity;
                        }
                    }
                    else if (animalType == "Cat")
                    {
                        if (foodType != "Vegetable" && foodType != "Meat")
                        {
                            Console.WriteLine($"Cat does not eat {foodType}!");
                        }
                        else
                        {
                            curAnimal.Weight += 0.3 * food.Quantity;
                            curAnimal.FoodEaten += food.Quantity;
                        }
                    }
                    else if (animalType == "Dog" || animalType == "Tiger" || animalType == "Owl")
                    {
                        if (foodType != "Meat")
                        {
                            Console.WriteLine($"{animalType} does not eat {foodType}!");
                        }
                        else if (animalType == "Dog")
                        {
                            curAnimal.Weight += 0.4 * food.Quantity;
                            curAnimal.FoodEaten += food.Quantity;
                        }
                        else if (animalType == "Tiger")
                        {
                            curAnimal.Weight += 1 * food.Quantity;
                            curAnimal.FoodEaten += food.Quantity;
                        }
                        else if (animalType == "Owl")
                        {
                            curAnimal.Weight += 0.25 * food.Quantity;
                            curAnimal.FoodEaten += food.Quantity;
                        }
                    }
                    else
                    {
                        curAnimal.Weight += 0.35 * food.Quantity;
                        curAnimal.FoodEaten += food.Quantity;
                    }
                    animals.Add(curAnimal);
                }
                tokens = Console.ReadLine()
                .Split();
                line++;
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
