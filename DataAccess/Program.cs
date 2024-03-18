// See https://aka.ms/new-console-template for more information

using MemoryBusiness;
using MemoryDatabase;

DataBaseManager a = new DataBaseManager();


Player player = new Player("Wouter");

player.Playerscore = 100;
player.Moves = 10;
a.InsertResult(player);


foreach (var VARIABLE in a.Results())
{
    Console.WriteLine($"{VARIABLE.PlayerName} heeft een score behaald van {VARIABLE.Playerscore} met {VARIABLE.Moves} beurten");
}