using System;

namespace searchFight
{
    public class IOUtils
    {
        private readonly String manualPath = "resources/manual.txt";

        public void printManual(){
            string manual = System.IO.File.ReadAllText(@manualPath);
            Console.Write(manual);
            return;
        }
    }
}
