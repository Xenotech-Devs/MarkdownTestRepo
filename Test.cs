using System;
using System.Linq;
using System.Threading.Tasks;

var rnd = new Random();

// Generate a random creature name
string[] prefixes = { "Glim", "Thra", "Nim", "Vor", "Zel", "Pip" };
string[] middles  = { "bloom", "crag", "whisp", "thorn", "spark", "loom" };
string[] suffixes = { "er", "ix", "on", "a", "us", "ae" };

string name = $"{Pick(prefixes)}{Pick(middles)}{Pick(suffixes)}";

// Random stats
int strength = rnd.Next(1, 11);
int agility  = rnd.Next(1, 11);
int magic    = rnd.Next(1, 11);
int health   = rnd.Next(10, 51);

// Small ASCII-art generator
var shapes = new Func<string>[] {
    () => @"  /\_/\  
 ( o.o ) 
  > ^ <",
    () => @"  .-.
 (o o)
  |=|",
    () => @"  /\ 
 /  \ 
/____\",
    () => @"  __
 (  )
  \/ "
};

string art = shapes[rnd.Next(shapes.Length)]();

// Print creature
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"Creature: {name}");
Console.ResetColor();

Console.WriteLine(art);
Console.WriteLine();
Console.WriteLine($"STR: {strength}  AGI: {agility}  MAG: {magic}  HP: {health}");
Console.WriteLine();

// A tiny async behavior: the creature "thinks" then does an action
await ThinkAndActAsync(name, rnd);

string Pick(string[] arr) => arr[rnd.Next(arr.Length)];

static async Task ThinkAndActAsync(string name, Random rnd)
{
    Console.Write("Thinking");
    for (int i = 0; i < 3; i++)
    {
        await Task.Delay(400);
        Console.Write(".");
    }
    Console.WriteLine();

    string[] actions = { "sings a weird tune", "naps in a sunspot", "casts a glittery spell", "stomps playfully" };
    string action = actions[rnd.Next(actions.Length)];

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{name} {action}.");
    Console.ResetColor();
}