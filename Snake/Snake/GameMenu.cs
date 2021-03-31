using System;
using System.Net.Mime;

namespace Snake
{
    public class GameMenu
        {
            public enum MenuOption
            {
                Exit,
                Play
            }

            public static MenuOption ProvideMenuOptions()
            {
                while (true)
                {
                    Console.Write("Want to play a game? ");
                    var input = Console.ReadLine();

                    if (input == "yes")
                    {
                        return MenuOption.Play;
                    }

                    if (input == "no")
                    {
                        return MenuOption.Exit;
                    }

                    Console.WriteLine("Try again");
                }
            }

            public static void HandleMenuAnswer(MenuOption answer)
            {
                switch (answer)
                {
                    case MenuOption.Play:
                        Game.InitGame();
                        break;
                    case MenuOption.Exit:
                       HttpService.GetLeaderboard();
                       Console.ForegroundColor = ConsoleColor.Yellow;
                       Console.WriteLine("You are lame. You should try to be more fun");
                       Console.WriteLine("Press ENTER if you changed your mind and want to play");

                       var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter)
                        {
                            Game.InitGame();
                        } 

                           

                       break;


                    default:
                        throw new ArgumentOutOfRangeException(nameof(answer),
                            answer, null);
                }
            }
        }
    }