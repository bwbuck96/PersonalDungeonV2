using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace DungeonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF DOOM!";

            Console.WriteLine("Your journey begins...\n");
            // 1 Create a Player & a Weapon

            Weapon sword = new Weapon("Falchion", false, 1, 5, 10);
            Player player = new Player("Garbok", 5, 30, 100, 100, Race.Tiefling, sword);
            int score = 0;


            //2. Create a Loop for the game

            bool exit = false;

            do
            {
                //3. Create a room - making a method to generate a room description.
                Console.WriteLine("You have now entered a room...\n");
                Console.WriteLine(GetRoom());

                // 4. Create a Monster
                Rabbit r1 = new Rabbit(); //This one uses the default values
                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 50, 20, 8, "That's no ordinary rabbit, look at the bones!", 2, true);

                //Since all of our monsters are the same type, we will create an array with a few instances of each rabbit above.
                //In your dungeon, put one instance of each kind of monster in the array.

                Monster[] monsters = { r1, r2, r1, r1, r2, r2, r1 };

                //Randomly select a monster from the array.
                Random rand = new Random();

                int randNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randNbr];

                Console.WriteLine("\nIn this room: " + monster.Name);


                //5. Create a Loop for the Menu
                bool reload = false;
                do
                {
                    //6. Provide the User with a Menu of Options
                    Console.WriteLine("\nPlease choose an action\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "W) Weapon Stats\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //7. Catch the user's choice
                    //string userChoice = Console.ReadLine().ToUpper(); ---OPTION 1
                    ConsoleKey userChoice = Console.ReadKey(true).Key; // -----OPTION 2

                    Console.Clear();

                    //8. Build out a switch to handle the user's choice.
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            // 9 Handle the combat logic & what happens if the player wins
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //it's dead
                                //Possible customization, player could get items, life, or something similar
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}\n", monster.Name);
                                Console.ResetColor();
                                //get a new room and new monster
                                reload = true; //Breaks out of interior loop.
                                //Update the players score. 
                                score++;
                            }

                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!!");
                            //TODO 10 Handle the user running away & the monster getting a free attack
                            Console.WriteLine($"{monster.Name} attacks as you flee!");
                            Combat.DoAttack(monster, player); //free attack, only the monster gets to attack here.
                            Console.WriteLine();
                            reload = true; //Get a new room and new monster, because player left the previous.


                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info: ");
                            // 11 Print out Player info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.W:
                            Console.WriteLine(sword);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info: ");
                            // 12 Print out Monster info
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Nobody likes a quitter! Boo!");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Triest though again.");
                            break;
                    }

                    // 13 Check the Player's life (health)
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude...you are already dead.");
                        exit = true;
                    }

                } while (!exit && !reload); //While exit AND reload are false, keep running

            } while (!exit);//While exit is false, keep running

            // 14 State the Player's Score (How many monsters were killed?)
            Console.WriteLine("Congrats! You slayed {0} monster{1}!", score, ((score == 1) ? "" : "s"));
        }
        private static string GetRoom()
        {
            string[] rooms =  {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;

        }
    }

}


