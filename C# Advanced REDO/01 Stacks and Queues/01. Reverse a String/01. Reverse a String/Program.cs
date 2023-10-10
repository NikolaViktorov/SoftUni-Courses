string input = Console.ReadLine();

Stack<char> letters = new Stack<char>();

foreach (var letter in input)
{
    letters.Push(letter);
}

while (letters.Count > 0)
{
    Console.Write(letters.Pop());
}