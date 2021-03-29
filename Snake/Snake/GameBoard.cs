using System;

namespace Snake
{
    public static class GameBoard
    {
        public static void BuildBoard()
        {
            Console.Clear();
            Console.WriteLine(" Carolinas amazing snake game        Use arrowkeys to move");
  

            for (int i = 1; i < 31; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(1, i);
                Console.Write("║");
                Console.SetCursorPosition(70, i);
                Console.Write("║");
            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(i,1);
                Console.Write("═");
                Console.SetCursorPosition(i,30);
                Console.Write("═");
            }
        }
    }
}