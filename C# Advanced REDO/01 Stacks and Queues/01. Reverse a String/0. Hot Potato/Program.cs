Queue<string> kids = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray());
int boomPass = int.Parse(Console.ReadLine());

int passes = 0;

while (kids.Count > 1)
{
    passes += 1;
    string potatoKid = kids.Dequeue();

    if (passes == boomPass)
    {
        passes = 0;
        Console.WriteLine($"Removed {potatoKid}");
    }
    else
    {
        kids.Enqueue(potatoKid);
    }

}

Console.WriteLine($"Last is {kids.Dequeue()}");

