// Julio Ruiz Matricula:2024-2009
Console.Write("Type the number: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    if (number % 2 == 0)
    {
        Console.WriteLine("The number is even.");
    }
    else
    {
        Console.WriteLine("The number is odd.");
    }
}
else
{
    Console.WriteLine("It isn't a number.");
}