using System;

namespace zhekud_app
{
    class SnakeGame
    {
        static int counter = 0;
        static readonly int max_counter = 3000;
        static bool gameStatus = true;
        static int snakeLength = 2;
        static int direction = 3; // 1 - up, 2 - down, 3 - right, 4 - left
        static int[] position = { 4, 3 };
        static int[,] field;
        static char presedKey;
        
        static void Main()
        {
            field = Field(10);
            field[position[0], position[1]] = snakeLength; // snake init
            RandomPointInit();

            while (gameStatus)
            {
                Loop();
            }
        }

        static void Loop()
        {
            if (counter <= max_counter) 
            { 
                counter += 1; 
            }
            else 
            { 
                counter = 0; 
            }
            int loop_counter = counter;

            Console.SetCursorPosition(0, 0);
            GameLogic(loop_counter);
            DrawGame();
            PlayerInput();
        }   

        static void DrawGame()
        {   
            if (counter == max_counter)
            {
                int rows = field.GetUpperBound(0) + 1;
                int columns = field.Length / rows;
                string grid = "";

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        grid += "\u253C\u2500\u2500\u2500";
                    }
                    grid += "\n";
                    for (int j = 0; j < columns; j++)
                    {
                        if (field[i, j] > 0)
                        {
                            grid += "\u2502 \u25A0 ";
                        }
                        else if (field[i, j] == -1)
                        {
                            grid += "\u2502 X ";
                        }
                        else
                        {
                            grid += "\u2502   ";
                        }
                    }
                    grid += "\n";
                }
                Console.WriteLine(grid);
                Console.WriteLine(snakeLength - 1);
            }
        }

        static void GameLogic(int counter)
        {
            if (counter == max_counter)
            {
                int rows = field.GetUpperBound(0) + 1;
                int columns = field.Length / rows;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        if (field[row, col] > 0)
                        {
                            field[row, col] -= 1;
                        }
                    }
                }

                if (direction == 1)
                {
                    position[0] -= 1;
                    if (position[0] < 0 || field[position[0], position[1]] > 0)
                    {
                        gameStatus = false;
                        return;
                    }
                    else if (field[position[0], position[1]] == -1)
                    {
                        snakeLength += 1;
                        RandomPointInit();
                    }
                    field[position[0], position[1]] = snakeLength;
                }
                else if (direction == 2)
                {
                    position[0] += 1;
                    if (position[0] > 9 || field[position[0], position[1]] > 0)
                    {
                        gameStatus = false;
                        return;
                    }
                    else if (field[position[0], position[1]] == -1)
                    {
                        snakeLength += 1;
                        RandomPointInit();
                    }
                    field[position[0], position[1]] = snakeLength;
                }
                else if (direction == 3)
                {
                    position[1] += 1;
                    if (position[1] > 9 || field[position[0], position[1]] > 0)
                    {
                        gameStatus = false;
                        return;
                    }
                    else if (field[position[0], position[1]] == -1)
                    {
                        snakeLength += 1;
                        RandomPointInit();
                    }
                    field[position[0], position[1]] = snakeLength;
                }
                else if (direction == 4)
                {
                    position[1] -= 1;
                    if (position[1] < 0 || field[position[0], position[1]] > 0)
                    {
                        gameStatus = false;
                        return;
                    }
                    else if (field[position[0], position[1]] == -1)
                    {
                        snakeLength += 1;
                        RandomPointInit();
                    }
                    field[position[0], position[1]] = snakeLength;
                }
            }
        }

        static void PlayerInput()
        {
            ConsoleKeyInfo input;
            if (Console.KeyAvailable)
            {
                input = Console.ReadKey();
                presedKey = input.KeyChar;
            }

            if (presedKey == 'w')
            {
                direction = 1;
            }
            else if (presedKey == 's')
            {
                direction = 2;
            }
            else if (presedKey == 'd')
            {
                direction = 3;
            }
            else if (presedKey == 'a')
            {
                direction = 4;
            }
        }

        static int[,] Field(int rank)
        {
            int[,] field = new int[rank, rank];
            return field;
        }

        static void RandomPointInit()
        {
            var rand = new Random();
            int n1 = rand.Next(0, 10);
            int n2 = rand.Next(0, 10);
            if (field[n1, n2] != 0)
            {
                RandomPointInit();
            }
            else
            {
                field[n1, n2] = -1;
            }
        }
    }
}
