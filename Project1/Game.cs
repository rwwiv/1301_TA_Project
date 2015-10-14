using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    public class Game
    {
        string scene = "Cell";

        bool firstTimeInRoom = true;
        int i = 0;


        bool drawerOpen = false;
        bool hasKey = false;
        string cellDoorState = "locked";

        public void Play()
        {
            while (scene != "GameOver")
            {
                if (scene == "Cell")
                {
                    Cell();
                }
                else if (scene == "LivingRoom")
                {
                    LivingRoom();
                }
                else if (scene == "Bedroom")
                {
                    Bedroom();
                }
                else if (scene == "Kitchen")
                {
                    Kitchen();
                }
                else if (scene == "Outside")
                {
                    Outside();
                }
                else
                {
                    GameTools.WriteColoredParagraph("ERROR: ROOM NOT FOUND!!!", ConsoleColor.White, ConsoleColor.Red);
                    scene = "GameOver";
                }
            }
        }


        private void Cell()
        {
            GameTools.ChangeTextColor(ConsoleColor.Red);
            if (firstTimeInRoom == true)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                GameTools.WriteParagraph(@"
You awake. A cold bed. Stone. The sound of water dripping. Plunk. 
No light. Where are you?! As your eyes adjust, you see smooth walls, a barred door.
A cell? Why?
            ");
                firstTimeInRoom = false;
            }
            else
            {
                Console.WriteLine();
                GameTools.ChangeTextColor(ConsoleColor.Black, ConsoleColor.White);
                Console.WriteLine("Cell");
                GameTools.ChangeTextColor(ConsoleColor.Red, ConsoleColor.Black);
                Console.WriteLine();
                GameTools.WriteParagraph(@"
You are still in the cell, still unsure why you ended up here.
");
            }
            Console.ResetColor();
            Console.WriteLine();
            if (cellDoorState.ToLower().Equals("unlocked") || cellDoorState.ToLower().Equals("open"))
            {
                GameTools.ChangeTextColor(ConsoleColor.Red);
                GameTools.WriteParagraph(@"However, the door is now {0}",cellDoorState);
                Console.ResetColor();
                Console.WriteLine();
            }

            if (i == 3)
            {
                Console.WriteLine();
                GameTools.ChangeTextColor(ConsoleColor.DarkCyan);
                GameTools.WriteParagraph(@"
You hear the sound of a key turn, and a voice whispers 
""You must be so bored, why don't you come out and have fun?""
");
                Console.ResetColor();
                Console.WriteLine();
                cellDoorState = "unlocked";
            }

            Console.Write("What do you do? ");
            string input = Console.ReadLine().ToLower();

            string[] wordList = input.Split(' ');

            //Console.WriteLine(GameTools.BetterVerb(wordList[0]).Equals("open")
            //    && GameTools.betterObject(wordList[1]).Equals("door")
            //    && i < 3);

            if (GameTools.BetterVerb(wordList[0]).Equals("wait"))
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("\nYou wait patiently for a couple minutes.");
                i++;
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("listen") && i != 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine();
                GameTools.WriteParagraph(@"You hear faint sounds from the other side of the door, but can't tell what they are.");
                i++;
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("listen") && i == 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine();
                GameTools.WriteParagraph(@"You hear someone walking away from the door.");
                i++;
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("open")
                && GameTools.betterObject(wordList[1]).Equals("door")
                && i < 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("\nThe door is locked...");
                i++;
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("open")
                && GameTools.betterObject(wordList[1]).Equals("door"))
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                GameTools.WriteParagraph(@"You open the now unlocked door into a darkened hallway. Maybe it's safer in the cell...");
                i++;
                cellDoorState = "open";
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("\nWhat are you trying to do?");
            }
            
        }

        private void Kitchen()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("KITCHEN:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
You are in a kitchen, complete with hideous 1960's yellow appliances. There
is some tasty looking food on an island in the center of the room. There
are also numerous instruments of cutting that look like they might be able
to slice through a wooden door, but you are such a pacifist, you won't
consider even harming a dead tree, so you ignore them. There are doors
to the south and west.
                ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (S)outh or (W)est, or you can (C)how down.", ConsoleColor.Black, ConsoleColor.Cyan);

            string choice = GameTools.GetChoice("s", "w", "c");

            if (choice == "s")
            {
                scene = "LivingRoom";
            }
            else if (choice == "w")
            {
                scene = "Cell";
            }
            else if (choice == "c")
            {
                Console.WriteLine();
                Console.WriteLine("Ooooohhhh man! That hit the spot!");
                scene = "Kitchen";
            }
        }

        private void Bedroom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("BEDROOM:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
You are in the bedroom. It is a plain bedroom with carpet, four beige
walls, and a bed.
                ");
            Console.WriteLine();

            string choice;
            if (drawerOpen == false)
            {
                GameTools.WriteParagraph(@"
You see a nightstand with a closed drawer. There are doors to the 
north and east.
                    ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (N)orth or (E)ast, or you can (O)pen the drawer.", ConsoleColor.Black, ConsoleColor.Cyan);
                choice = GameTools.GetChoice("n", "e", "o");
            }
            else if (hasKey == false)
            {
                GameTools.WriteParagraph(@"
You see a nightstand with an open drawer. Inside the drawer is a key.
There are doors to the north and east.
                    ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (N)orth or (E)ast, or you can (T)ake the key.", ConsoleColor.Black, ConsoleColor.Cyan);
                choice = GameTools.GetChoice("n", "e", "t");
            }
            else
            {
                GameTools.WriteParagraph(@"
You see a nightstand with an open drawer. The drawer appears to be empty.
There are doors to the north and east.
                ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (N)orth or (E)ast.", ConsoleColor.Black, ConsoleColor.Cyan);
                choice = GameTools.GetChoice("n", "e");
            }

            if (choice == "n")
            {
                scene = "Cell";
            }
            else if (choice == "e")
            {
                scene = "LivingRoom";
            }
            else if (choice == "o")
            {
                drawerOpen = true;
                scene = "Bedroom";
            }
            else if (choice == "t")
            {
                hasKey = true;
                scene = "Bedroom";
            }
        }

        private void LivingRoom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("LIVING ROOM:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
You are standing in a living room. It has beautiful hardwood floors, a
pfabulous plush couch, an amazing antique coffee table, and a ridiculously
tacky replica of the Mona Lisa on a canvas hanging on the wall.
In addition to open doors to the west and north, the front door to the
house appears to be to your south.
                ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (N)orth or (W)east or (S)outh.", ConsoleColor.Black, ConsoleColor.Cyan);

            string choice = GameTools.GetChoice("n", "w", "s");

            if (choice == "n")
            {
                scene = "Kitchen";
            }
            else if (choice == "w")
            {
                scene = "Bedroom";
            }
            else if (choice == "s")
            {
                if (hasKey == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("You unlock the front door and step...");
                    scene = "Outside";
                }
                else
                {
                    Console.WriteLine();
                    GameTools.WriteColoredParagraph(@"
Hmm, the door appears to be locked. What's a person to do? I mean how can you
possibly get past a locked door? Oh gee, I think I might be trapped in here forever.
                    ", ConsoleColor.Red, ConsoleColor.Yellow);
                    scene = "LivingRoom";
                }
            }
        }

        private void Outside()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("OUTSIDE:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            Console.WriteLine("You are standing outside. Well, that's it. Wasn't this a fun game?");
            Console.WriteLine();
            Console.WriteLine("Thanks for playing!!");
            Console.WriteLine();
            scene = "GameOver";
        }
    }
}
