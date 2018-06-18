using System;
using System.Diagnostics;

namespace bash_executor
{
    /**
     * Classe que encapsula els diferents mètodes d'execució dels altres llenguatges.
     */
    public static class ShellHelper {
        /**
         * Extension method. 
         * -> S'ha de declarar fóra de les classes principals per aquest motiu s'ha afegit a la classe ShellHelper. 
         * -> Extén la classe String amb el mètode bash per poder fer crides com : 
         *      "ps -ef".bash();
         * @param cmd és la instrucció que reb el mètode. 
         */
        public static String Bash(this string cmd)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "/bin/bash",
                    UseShellExecute = false,
                    Arguments = $"-c \"{cmd}\"",
                    RedirectStandardOutput = true
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }

    /**
     * Main... 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string output = ("ps -ef").Bash();
            Console.WriteLine(output);
        }
    }
}
