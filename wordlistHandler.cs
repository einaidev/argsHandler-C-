using System;
using System.IO;
using Errors;


namespace Wordlist {
    class WordlistHandler {
        public static List<string> WdLoader(string args){
            var list = new List<string>();
            string path = args.ToString();
            
            if(!path.EndsWith(".txt")){
                throw new ExtensionError("the file don't ends with txt. only txt files are suported");
            }
            // Console.WriteLine(path);
            if (File.Exists(path)) {
                string txt = File.ReadAllText(path);
                list = txt.Split("\n").ToList();

            } else {
                throw new WordlistFileDontExist("file cannot been found");
            }
            

            return list ;
        }
    }
}