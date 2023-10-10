Stack<int> numStack = new Stack<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

string[] cmd = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
while (cmd[0] != "end")
{
    if (cmd[0] == "add")
    {
        numStack.Push(int.Parse(cmd[1]));
        numStack.Push(int.Parse(cmd[2]));
    } 
    else
    {
        int removedNumsCount = int.Parse(cmd[1]);
        if (removedNumsCount <= numStack.Count)
        {
            for (int i = 0; i < removedNumsCount; i++)
            {
                numStack.Pop();
            }
        }
    }
    cmd = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
}
Console.WriteLine("Sum: " + numStack.Sum());