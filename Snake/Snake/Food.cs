using System;
using System.ComponentModel.Design.Serialization;

namespace Snake
{
    public class Food
    {
        public static void PlaceFood(out int foodX, out int foodY)
        {
            var random = new Random();
            foodX = random.Next(2, 68);
            foodY = random.Next(2, 28);
            
            Console.SetCursorPosition(foodX, foodY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("#");

        }

        public static bool IsFoodEaten(int positionX, int positionY, int foodX, int foodY)
        {
            if (positionX == foodX && positionY == foodY)
                return true;
            return false;
        } 
    }
}