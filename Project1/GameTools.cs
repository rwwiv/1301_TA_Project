using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class GameTools
{
    /// <summary>
    /// Prompts the user to type one of a set of possible valid text values.
    /// User is prompted repeatedly until she enters one of the valid choices.
    /// Choices are not case sensitive.
    /// </summary>
    /// <param name="validChoices">a comma separated list of valid choices</param>
    /// <returns></returns>
    public static string GetChoice(params string[] validChoices)
    {
        string choice = "";
        bool isValid = false;
        while (isValid == false)
        {
            string choiceString = String.Join(" | ", validChoices);
            Console.Write("Enter Choice ({0}): ", choiceString);
            choice = Console.ReadLine();
            //choice = choice.ToLower();
            foreach (string validChoice in validChoices)
            {
                if (choice.Equals(validChoice, StringComparison.InvariantCultureIgnoreCase))
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid == false)
            {
                WriteColoredParagraph("Invalid Choice. Try Again.", ConsoleColor.White, ConsoleColor.DarkRed);
            }
        }
        return choice;
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    public static void WriteParagraph(string text)
    {
        WriteParagraph(text, new { });
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    /// <param name="args">any replaceable parameters included in text using {#} syntax</param>
    public static void WriteParagraph(string text, params object[] args)
    {
        text = String.Format(text, args);
        Console.WriteLine(String.Join(Environment.NewLine, GetWrappedText(text)));
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces. The specified foreground
    /// and background colors will be used.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    /// <param name="foreground">the foreground color to use when writing the text</param>
    /// <param name="background">the background color to use when writing the text</param>
    public static void WriteColoredParagraph(string text, ConsoleColor foreground, ConsoleColor background)
    {
        WriteColoredParagraph(text, foreground, background, new { });
    }

    /// <summary>
    /// Write text to the screen, inserting new lines at appropriate places
    /// in order to properly wrap the text only at spaces. The specified foreground
    /// and background colors will be used.
    /// </summary>
    /// <param name="text">the text to write to the screen</param>
    /// <param name="foreground">the foreground color to use when writing the text</param>
    /// <param name="background">the background color to use when writing the text</param>
    /// <param name="args">any replaceable parameters included in text using {#} syntax</param>
    public static void WriteColoredParagraph(string text, ConsoleColor foreground, ConsoleColor background, params object[] args)
    {
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        text = String.Format(text, args);
        List<string> lines = GetWrappedText(text);
        foreach (string line in lines)
        {
            Console.Write(line.PadRight(Console.WindowWidth));
        }
        Console.ResetColor();
    }

    /// <summary>
    /// Returns a list of string lines that have been sized such that each line
    /// doesn't exceed the length of hte console window.
    /// </summary>
    /// <param name="text">the text to wrap</param>
    /// <returns></returns>
    private static List<string> GetWrappedText(string text)
    {
        List<string> lines = new List<string>();
        StringBuilder sb = new StringBuilder();

        if (text != null)
        {
            text = Regex.Replace(text, @"\s+", " ").Trim();
            string[] words = text.Split(' ');

            for (int wordNum = 0; wordNum < words.Length; wordNum++)
            {
                String word = words[wordNum];
                if (sb.Length != 0 && (sb.Length + word.Length + 2) > Console.WindowWidth)
                {
                    lines.Add(sb.ToString());
                    sb.Clear();
                }
                sb.Append(word).Append(' ');
            }
        }

        lines.Add(sb.ToString());
        return lines;
    }
    /// <summary>
    /// Changes foreground and background color in console
    /// </summary>
    /// <param name="colors">First is foreground, second is background</param>
    public static void ChangeTextColor(params ConsoleColor[] colors)
    {
        if (colors.Length == 1)
        {
            Console.ForegroundColor = colors[0];
        }
        else if (colors.Length == 2)
        {
            Console.ForegroundColor = colors[0];
            Console.BackgroundColor = colors[1];
        }
    }

    public static string BetterVerb(string input)
    {
        Dictionary<string, string[]> dictVerb = new Dictionary<string, string[]>()
        {
            {"take", new string[] { "grab" , "take" } },
            {"use" , new string[] { "use" } },
            {"throw", new string[] { "toss" , "throw " , "lob"} },
            {"wait", new string[] { "wait", "pause"} },
            {"listen", new string[] { "listen" , "hear" , "eavesdrop"} },
            {"check", new string[] { "check" } },
            {"open", new string[] { "open" , "pull"} }

        };

        foreach (string verb in dictVerb.Keys)
        {
            foreach (string synonym in dictVerb[verb])
            {
                if (input.Contains(synonym))
                {
                    return verb;
                }
            }
        }
        return "";
    }

    public static string betterObject(string input)
    {
        Dictionary<string, string[]> dictNoun = new Dictionary<string, string[]>()
        {
            {"door", new string[] { "door", "barred door", "solid door"} }

        };

        foreach (string wordObject in dictNoun.Keys)
        {
            foreach (string synonym in dictNoun[wordObject])
            {
                if (input.Contains(synonym))
                {
                    return wordObject;
                }
            }
        }
        return "";
    }
}
