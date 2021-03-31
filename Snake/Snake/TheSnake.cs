using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public static class TheSnake
    {
        private static int[] PositionX { get; set; } = new int[2100];
        private static int[] PositionY { get; set; } = new int[2100];
        private static int Velocity { get; set; } = 200;
        private static int FoodEaten { get; set; } = 0;
        private static bool GameOver { get; set; } = false;


        public static void MoveSnake()
        {
            PositionX[0] = 35;
            PositionY[0] = 15;

            DrawSnake();
            Food.PlaceFood(out var foodX, out var foodY);
            var command = Console.ReadKey().Key;

            while (!GameOver)
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(PositionX[0], PositionY[0]);
                        Console.Write(" ");
                        PositionX[0]--;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(PositionX[0], PositionY[0]);
                        Console.Write(" ");
                        PositionX[0]++;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(PositionX[0], PositionY[0]);
                        Console.Write(" ");
                        PositionY[0]--;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(PositionX[0], PositionY[0]);
                        Console.Write(" ");
                        PositionY[0]++;
                        break;
                }

                DrawSnake();
                if (Food.IsFoodEaten(PositionX[0], PositionY[0], foodX, foodY))
                {
                    Food.PlaceFood(out foodX, out foodY);
                    FoodEaten++;
                    Velocity -= 2;
                }


                if (PositionX[0] == 1 || PositionX[0] == 70 || PositionY[0] == 1 || PositionY[0] == 30 ||
                    DidEatItself())
                {
                    GameOver = true;
                    var score = FoodEaten * 10;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(30, 5);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(30, 6);
                    Console.WriteLine($"Score: {score}");
                    Console.SetCursorPosition(18, 7);
                    Console.Write("Enter name for leaderboard:");
                    Console.CursorVisible = true; 
                    var name = Console.ReadLine();
                    Console.CursorVisible = false;
                    HttpService.PostScore(score, name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press ENTER to play again");

                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    if (!IsOppositeKeyOrInvalid(command, key))
                        command = key;
                }

                Thread.Sleep(Velocity);
            }

            while (GameOver)
            {
                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.Enter:
                        ResetGameScore();
                        Game.InitGame();

                        break;
                }
            }
        }

        private static async Task LeaderboardStuff(int score)
        {
            // HttpService.PostScore(score, "temp");
            // Console.WriteLine(await HttpService.GetLeaderboard());
        }

        private static void ResetGameScore()
        {
            PositionX[0] = 30;
            PositionY[0] = 15;
            FoodEaten = 0;
            Velocity = 200;
            GameOver = false;
        }

        private static bool IsOppositeKeyOrInvalid(ConsoleKey command, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return command == ConsoleKey.RightArrow;
                case ConsoleKey.RightArrow:
                    return command == ConsoleKey.LeftArrow;
                case ConsoleKey.UpArrow:
                    return command == ConsoleKey.DownArrow;
                case ConsoleKey.DownArrow:
                    return command == ConsoleKey.UpArrow;
            }

            return true;
        }

        private static void DrawSnake()
        {
            Console.SetCursorPosition(PositionX[0], PositionY[0]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("O");

            for (var i = 1; i < FoodEaten + 1; i++)
            {
                Console.SetCursorPosition(PositionX[i], PositionY[i]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("o");
            }


            Console.SetCursorPosition(PositionX[FoodEaten + 1], PositionY[FoodEaten + 1]);
            Console.WriteLine(" ");


            for (var i = FoodEaten + 1; i > 0; i--)
            {
                PositionX[i] = PositionX[i - 1];
                PositionY[i] = PositionY[i - 1];
            }
        }

        private static bool DidEatItself()
        {
            var coordinates = new List<(int x, int y)>();

            for (var i = 0; i <= FoodEaten + 1; i++)
            {
                coordinates.Add((PositionX[i], PositionY[i]));
            }


            var groupedCoordinates = coordinates.GroupBy(coordinate => coordinate).ToList();
            return FoodEaten == groupedCoordinates.Count;
        }
    }
}