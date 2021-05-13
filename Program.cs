using System;

namespace XOTraining
{
    class Program
    {
        static string[,] field = new string[9, 9]
            {
                {" ", " ", " |", " ", " ", " |", " ", " ", " "},
                {" ", "1", " |", " ", "2", " |", " ", "3", " "},
                {"_", "_", "_|", "_", "_", "_|", "_", "_", "_"},
                {" ", " ", " |", " ", " ", " |", " ", " ", " "},
                {" ", "4", " |", " ", "5", " |", " ", "6", " "},
                {"_", "_", "_|", "_", "_", "_|", "_", "_", "_"},
                {" ", " ", " |", " ", " ", " |", " ", " ", " "},
                {" ", "7", " |", " ", "8", " |", " ", "9", " "},
                {" ", " ", " |", " ", " ", " |", " ", " ", " "},
            };
        static bool player1Win;
        static bool player2Win;
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.Clear();
            Console.WriteLine("X always go first.\n");
            NewField();
            GameLogic();
        }

        static public void Field()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.Write("\n");
            }
        }

        static void NewField()
        {
            field = new string[9, 9]{
                { " ", " ", " |", " ", " ", " |", " ", " ", " "},
                { " ", "1", " |", " ", "2", " |", " ", "3", " "},
                { "_", "_", "_|", "_", "_", "_|", "_", "_", "_"},
                { " ", " ", " |", " ", " ", " |", " ", " ", " "},
                { " ", "4", " |", " ", "5", " |", " ", "6", " "},
                { "_", "_", "_|", "_", "_", "_|", "_", "_", "_"},
                { " ", " ", " |", " ", " ", " |", " ", " ", " "},
                { " ", "7", " |", " ", "8", " |", " ", "9", " "},
                { " ", " ", " |", " ", " ", " |", " ", " ", " "},
            };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.Write("\n");
            }
        }

        static void GameLogic()
        {
            int turns;
            player1Win = false;
            player2Win = false;
            for (turns = 1; turns < 10; turns++)
            {
                if (turns%2 != 0 && player1Win == false && player2Win == false) 
                {
                    Player1Turn();
                    CheckWin();
                }
                else if (turns%2 == 0 && player1Win == false && player2Win == false)
                {
                    Player2Turn();
                    CheckWin();
                }
                else if (player1Win == true && player2Win == false)
                {
                    Console.WriteLine("Player 1 wins!");
                    break;
                }
                else if (player2Win == true && player1Win == false)
                {
                    Console.WriteLine("Player 2 wins!");
                    break;
                }
            }
            if (player2Win == false && player1Win == false && turns == 10)
            {
                Console.WriteLine("Game over. Nobody won.");
            }
            Console.WriteLine("Would you like to restart? Press Y for Yes and any other key for No.");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Run();
            }
            else
            {
                Console.WriteLine("\nThanks for playing! The game will now close.");
            }
        }

        static void Player1Turn()
        {
            Console.Write("\nPlayer 1 turn. Pick a spot to put your sign to. ");
            int player1;
            bool player1Input = int.TryParse(Console.ReadLine(), out player1);
            if (player1Input)
            {
                switch (player1)
                {
                    case 1:
                        Player1Move(1, 1);
                        break;
                    case 2:
                        Player1Move(1, 4);
                        break;
                    case 3:
                        Player1Move(1, 7);
                        break;
                    case 4:
                        Player1Move(4, 1);
                        break;
                    case 5:
                        Player1Move(4, 4);
                        break;
                    case 6:
                        Player1Move(4, 7);
                        break;
                    case 7:
                        Player1Move(7, 1);
                        break;
                    case 8:
                        Player1Move(7, 4);
                        break;
                    case 9:
                        Player1Move(7, 7);
                        break;
                    default:
                        Console.WriteLine("Wrong spot has been selected. Please, select a spot from 1 to 9.");
                        Player1Turn();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Very funny. Now, please, select the spot from the game field.");
                Player1Turn();
            }
        }

        static void Player2Turn()
        {
            Console.Write("\nPlayer 2 turn. Pick a spot to put your sign to. ");
            int player2;
            bool player2Input = int.TryParse(Console.ReadLine(), out player2);
            if (player2Input)
            {
                switch (player2)
                {
                    case 1:
                        Player2Move(1, 1);
                        break;
                    case 2:
                        Player2Move(1, 4);
                        break;
                    case 3:
                        Player2Move(1, 7);
                        break;
                    case 4:
                        Player2Move(4, 1);
                        break;
                    case 5:
                        Player2Move(4, 4);
                        break;
                    case 6:
                        Player2Move(4, 7);
                        break;
                    case 7:
                        Player2Move(7, 1);
                        break;
                    case 8:
                        Player2Move(7, 4);
                        break;
                    case 9:
                        Player2Move(7, 7);
                        break;
                    default:
                        Console.WriteLine("Wrong spot has been selected. Please, select a spot from 1 to 9.");
                        Player2Turn();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Very funny. Now, please, select the spot from the game field.");
                Player2Turn();
            }
        }

        static void Player1Move(int i, int j)
        {
            if (field[i, j] != "X" && field[i, j] != "O")
            {
                field[i, j] = "X";
                Reclear();
            }
            else
            {
                Console.WriteLine("Occupied spot has been selected. Please, select an unoccupied spot.");
                Player1Turn();
            }
        }

        static void Player2Move(int i, int j)
        {
            if (field[i, j] != "X" && field[i, j] != "O")
            {
                field[i, j] = "O";
                Reclear();
            }
            else
            {
                Console.WriteLine("Occupied spot has been selected. Please, select an unoccupied spot.");
                Player2Turn();
            }
        }

        static void CheckWin()
        {
            if ((field[1, 1].Equals("X") && field[4, 1].Equals("X") && field[7, 1].Equals("X")) ||
                (field[1, 1].Equals("X") && field[1, 4].Equals("X") && field[1, 7].Equals("X")) ||
                (field[1, 1].Equals("X") && field[4, 4].Equals("X") && field[7, 7].Equals("X")) ||
                (field[1, 4].Equals("X") && field[4, 4].Equals("X") && field[7, 4].Equals("X")) ||
                (field[1, 7].Equals("X") && field[4, 7].Equals("X") && field[7, 7].Equals("X")) ||
                (field[4, 1].Equals("X") && field[4, 4].Equals("X") && field[4, 7].Equals("X")) ||
                (field[7, 1].Equals("X") && field[7, 4].Equals("X") && field[7, 7].Equals("X")) ||
                (field[7, 1].Equals("X") && field[4, 4].Equals("X") && field[1, 7].Equals("X")))
            {
                player1Win = true;
            }
            if ((field[1, 1].Equals("O") && field[4, 1].Equals("O") && field[7, 1].Equals("O")) ||
                (field[1, 1].Equals("O") && field[1, 4].Equals("O") && field[1, 7].Equals("O")) ||
                (field[1, 1].Equals("O") && field[4, 4].Equals("O") && field[7, 7].Equals("O")) ||
                (field[1, 4].Equals("O") && field[4, 4].Equals("O") && field[7, 4].Equals("O")) ||
                (field[1, 7].Equals("O") && field[4, 7].Equals("O") && field[7, 7].Equals("O")) ||
                (field[4, 1].Equals("O") && field[4, 4].Equals("O") && field[4, 7].Equals("O")) ||
                (field[7, 1].Equals("O") && field[7, 4].Equals("O") && field[7, 7].Equals("O")) ||
                (field[7, 1].Equals("O") && field[4, 4].Equals("O") && field[1, 7].Equals("O")))
            {
                player2Win = true;
            }
        }

        static void Reclear()
        {
            Console.Clear();
            Field();
        }
    }
}
