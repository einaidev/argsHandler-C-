using System;
using Wordlist;
using Errors;




namespace args
{
    public class argsHandler
    {
        public static List<string> Valids = new List<string>(){
                "-w|--wordlist:path&path to you wordlist file",
                "-u|--url:url&url to u website",
        };
        public static void PrintMenu(string i)
        {
            string menu = string.Format("{0} is'nt a valid arg. Show te valid args below:\n", i.Split("=")[0]);
            foreach (var v in Valids)
            {

                var desc = v.ToString()?.Split(':', '&', '|');

                menu += "   " + desc[0] + " or " + desc[1] + string.Concat(Enumerable.Repeat(" ", (12 - desc[1].Length))) +
                "| Type: " + desc[2] + "." + string.Concat(Enumerable.Repeat(" ", (10 - desc[2].Length))) + " Description: " + desc[2] + ".\n";


            }
            Console.WriteLine(menu);
        }
        public static List<string> Wordlist = new List<string>();
        public static Dictionary<string, List<string>> args(params string[] args)
        {
            // Console.WriteLine("[{0}]", string.Join(", ", args));
            var must = new List<string>(){
                "wordlist", "url"
            };

            var foundArgs = new List<string>()
            {

            };

            var validArgs = new string[] { "-w", "--wordlist" };
            var list = new Dictionary<string, List<string>>()
            {

            };


            Dictionary<object, List<string>> types = new Dictionary<object, List<string>>(){
                {"wordlist", new List<string>(){
                    "-w", "--wordlist"
                }},
                {"url", new List<string>(){
                    "-u", "--url"
                }}

            };

            // Dictionary<string, object> functions = new Dictionary<string, object>() {
            //             {"wordlist", list.Add(WordlistHandler.WdLoader(path))}
            //         }

            args.ToList().ForEach(i =>
            {
                if (i.StartsWith("-") || i.StartsWith("--"))
                {
                    if (i.Contains("=")){

                        var arg = i.Split('=');
                        if (types["wordlist"].Contains(arg[0])) {
                            foundArgs.Add("wordlist");
                            var wd = WordlistHandler.WdLoader(arg[1]);
                            list.Add("wordlist", wd); 

                        } else if (types["url"].Contains(arg[0])){
                            foundArgs.Add("url");      
                            list.Add("url", new List<string>(){
                                arg[1]
                            }); 

                        } else {
                            throw new InvalidArg($"{arg[0]} is a invalid arg");
                        }

                    } else {
                        PrintMenu(i.Split("=")[0]);
                        Environment.Exit(exitCode:1);
                    }
                }
                else
                {
                    PrintMenu(i.Split("=")[0]);
                    Environment.Exit(exitCode:1);

                }
            });


            must.ForEach(i => {
                if(!foundArgs.Contains(i)) {
                        throw new MissgingArgument($"missing armument: {i}");
                    }
                });
            return list;
        }
    }
}

// caso esteja usando esse arquivo como o arquivo main... crie uma static void Main(params string[] args) e depois passe args como argumento