using System;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTitle();

            var menuAnswer = GameMenu.ProvideMenuOptions();
            Console.CursorVisible = false;
            GameMenu.HandleMenuAnswer(menuAnswer);
        }

        private static void PrintTitle()
        {
            Console.Title = "Carolinas Snake";
            const string title = @"       
      _    _
   ,-(|)--(|)-.
   \_   ..   _/
     \______/
       V  V                                  ____
       `.^^`.                               /^,--`
         \^^^\                             (^^\
         |^^^|                  _,-._       \^^\
        (^^^^\      __      _,-'^^^^^`.    _,'^^)
         \^^^^`._,-'^^`-._.'^^^^__^^^^ `--'^^^_/
          \^^^^^ ^^^_^^^^^^^_,-'  `.^^^^^^^^_/ 
           `.____,-' `-.__.'        `-.___.'    

 ";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title);
            Console.WriteLine(" ");
        }
    }
}