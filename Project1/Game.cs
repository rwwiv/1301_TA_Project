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
        string cellDoorState = "locked";


        public void Play()
        {
            while (scene != "GameOver")
            {
                if (scene == "Cell")
                {
                    Cell();
                }
                else if (scene == "Hallway1")
                {
                    Hallway1();
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
            if (firstTimeInRoom == true)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                GameTools.ChangeTextColor(ConsoleColor.Red);
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
                Console.Write("Cell");
                //Somtimes bugs out and writes white line if not like this
                GameTools.ChangeTextColor(ConsoleColor.Red, ConsoleColor.Black);
                Console.WriteLine();
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


            //Console.WriteLine(betterVerb.Equals("open")
            //    && betterObject.Equals("door")
            //    && i < 3);

            if (wordList.Length == 2
                && GameTools.BetterVerb(wordList[0]).Equals("wait")
                && GameTools.betterObject(wordList[1]).Equals("impatiently"))
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.Write("\nYou wait");
                GameTools.ChangeTextColor(ConsoleColor.Red);
                Console.Write(" impatiently ");
                Console.ResetColor();
                Console.Write("for a couple minutes.");
                i++;
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("wait"))
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
                GameTools.WriteParagraph(@"You open the now unlocked door into a dimly lit hallway. Maybe it's safer in the cell...");
                i++;
                cellDoorState = "open";
            }
            else if (wordList.Length == 1
                && GameTools.BetterVerb(wordList[0]).Equals("open"))
            {
                Console.WriteLine("Open what?");
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("go")
                && GameTools.betterObject(wordList[1]).Equals("door"))
            {
                scene = "Hallway1";
                firstTimeInRoom = true;
            }
            else if (GameTools.BetterVerb(wordList[0]).Equals("cheatCode1"))
            {
                scene = "Hallway1";
                firstTimeInRoom = true;
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("\nWhat are you trying to do?");
            }
            if (i == 15)
            {
                GameTools.WriteParagraph(@"
Well, you waited too long and now you're dead.... Good Job?
");
                scene = "GameOver";
            }
        }
        private void Hallway1()
        {
            if (firstTimeInRoom == true)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }
                GameTools.ChangeTextColor(ConsoleColor.Red);
                GameTools.WriteParagraph(@"
You enter the hallway. The area in front of you is dimly lit by the torches on either side of the tight walls.
The sounds you heard earlier are slightly more distinct, although you still can't make out the source.
");
                Console.ResetColor();
                Console.WriteLine();
                firstTimeInRoom = false;
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine();
                }

            }
        }
   }
}
