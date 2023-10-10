int pass = int.Parse(Console.ReadLine());

string cmd = Console.ReadLine();
Queue<string> cars = new Queue<string>();
int passedCars = 0;

while (cmd != "end")
{
	if (cmd == "green")
	{
		if (cars.Count >= pass)
		{
            for (int i = 0; i < pass; i++)
            {
                Console.WriteLine(cars.Dequeue() + " passed!");
                passedCars++;
            }
        }
		else
		{
			while (cars.Count > 0)
			{
                Console.WriteLine(cars.Dequeue() + " passed!");
                passedCars++;
            }
		}
    }
    else
	{
		cars.Enqueue(cmd);
	}
    cmd = Console.ReadLine();
}

Console.WriteLine($"{passedCars} cars passed the crossroads.");