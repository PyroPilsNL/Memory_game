// See https://aka.ms/new-console-template for more information

using MemoryBusiness;

Console.WriteLine("Hoe heet je?");

string naam = Console.ReadLine();

MemoryGame a = new MemoryGame(naam);

Console.WriteLine("Hoeveel paren wil je?");

var paren = Console.ReadLine();

a.StartGame(Convert.ToInt32(paren),true);