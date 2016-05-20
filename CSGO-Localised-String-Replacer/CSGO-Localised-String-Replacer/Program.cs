using System;
using System.Text;
using System.IO;

namespace CSGO_Localised_String_Replacer
{
    public class LocalisedStringReplacer
    {
        public static void ReplaceStrings(string pathCsgo, string pathIni)
        {
            if (File.Exists(pathCsgo))
            {
                Console.Write(Path.GetFileName(pathCsgo) + " was found." + "\n");
                if (File.Exists(pathIni))
                {
                    Console.Write(Path.GetFileName(pathIni) + " was found." + "\n\n");

                    string[] contents = File.ReadAllLines(pathCsgo);
                    Console.Write("Parsing " + Path.GetFileName(pathCsgo) + "\n");

                    string[] strings = File.ReadAllLines(pathIni);
                    Console.Write("Parsing " + Path.GetFileName(pathIni) + "\n\n");

                    for (int i = 0; i < contents.Length; i++)
                    {
                        var line = contents[i];

                        foreach (var str in strings)
                        {
                            var equalsIndex = str.IndexOf('=');
                            if (equalsIndex != -1)
                            {
                                var field = "\"" + str.Substring(0, equalsIndex) + "\"";

                                if (line.Contains(field))
                                {
                                    Console.Write("Found string " + field + " at line " + i + "\n");
                                    var translation = str.Substring(equalsIndex + 1, str.Length - equalsIndex - 1);
                                    contents[i] = field + "\t" + translation;
                                    Console.Write("Replaced value of string " + field + " at line " + i + " with " + translation + "\n\n");
                                }
                            }
                        }
                    }
                    Console.Write("Writing changes to " + Path.GetFileName(pathCsgo) + "\n\n");
                    File.WriteAllLines(pathCsgo, contents, Encoding.Unicode);

                    Console.Write("Finished!" + "\n");
                }
                else
                {
                    Console.Write(Path.GetFileName(pathIni) + " was not found at the given directory." + "\n");
                }
            }
            else
            {
                Console.Write(Path.GetFileName(pathCsgo) + " was not found at the given directory." + "\n");
            }
        }
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("The location of the CS:GO localisation file needs to be specified as the first command-line argument." + "\n");
            }
            else
            {
                if (args.Length == 1)
                {
                    Console.Write(
                        "The location of the replacer configuration file needs to be specified as the second command-line argument." + "\n");
                }
                else
                {
                    ReplaceStrings(args[0], args[1]);
                }
            }
            Console.Read();
        }
    }
}
