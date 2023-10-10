char[] exp = Console.ReadLine().ToCharArray();

Stack<int> openingBrackets = new Stack<int>();

for (int i = 0; i < exp.Length; i++)
{
    if (exp[i] == '(')
    {  
        openingBrackets.Push(i);
        continue;
    }
    else if (exp[i] == ')')
    {
        int openIndex = openingBrackets.Pop();
        for (int j = openIndex; j <= i; j++)
        {
            Console.Write(exp[j]);
        }
        Console.WriteLine();
    }
}


