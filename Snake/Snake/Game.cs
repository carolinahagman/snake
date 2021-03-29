namespace Snake
{
    public class Game
    {
        
        public static void InitGame()
        {
            GameBoard.BuildBoard();
            TheSnake.MoveSnake();
        }
        
    }
}