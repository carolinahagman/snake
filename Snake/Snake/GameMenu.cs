using System;

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
                        Console.WriteLine("You are fucking boring.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(answer),
                            answer, null);
                }
            }
        }
    }