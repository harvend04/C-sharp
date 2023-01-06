using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tictac
{
    internal class Program
    {
        //make an array with Number as indicator 
        static char[] Num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //start with player 1
        static int stat = 0; // to keep the game running as long it it not -1 or 1
        static void Main(string[] args)
        {
            do
            {
                jumps:// as check point to go back if the input is invalid
                Console.Clear();// clearing the screen each time the loop runs
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//checking the chance of the player
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Display();// calling the Display
                string input = Console.ReadLine(); //receiveing the user input as string
                int numVal = -1;
                if (!int.TryParse(input, out numVal)) //checking if the user input is integer or not 
                {
                    Console.WriteLine("Invalid Input!");
                    Thread.Sleep(750); //pause for brief moment before jumping to the checkpoint 
                    goto jumps;
                }
                else
                {
                    int choice = Convert.ToInt32(input); //convert the input to integer
                    if (choice > 9 || choice < 0)
                    {
                        Console.WriteLine("Invalid Moves!");
                        Thread.Sleep(750);
                        goto jumps;
                    }
                    else
                    {
                        if (Num[choice] != 'O' && Num[choice] != 'X') //checking if the user input already marked or not
                        {
                            if (player % 2 == 0) //if chance is of player 2 then mark O else mark X
                            {
                                Num[choice] = 'O';
                                player--;
                            }
                            else
                            {
                                Num[choice] = 'X';
                                player++;
                            }
                        }
                        else //If the cell already marked it will restart the loop again
                        {
                            Console.WriteLine($"Sorry the cell {choice} is already marked with {Num[choice]}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Please choose again.....");
                            Thread.Sleep(1000);
                        }
                    }
                }
                stat = checkWin();// calling of check win
            }
            while (stat == 0);
            // This loop will be run until all cell is marked
            Console.Clear();// clearing the console
            Display();// Display the final result of the board
            if (stat == 1)
            // if stat value is 1 then someone that marked the board last win the game
            {
                Console.WriteLine($"Player {player % 2 + 1} has won");
            }
            else// if stat value is -1 the match will be draw and no one win
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        // Display method to display the tic tac toe board
        public static void Display()
        {
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {Num[1]}  |  {Num[2]}  |  {Num[3]}");
            Console.WriteLine($"_____|_____|_____ ");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {Num[4]}  |  {Num[5]}  |  {Num[6]}");
            Console.WriteLine($"_____|_____|_____ ");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {Num[7]}  |  {Num[8]}  |  {Num[9]}");
            Console.WriteLine($"     |     |      ");
        }
        //Checking that any player has won or not
        public static int checkWin()
        {
            //Winning Condition Horizonal
            //1
            if (Num[1] == Num[2] && Num[2] == Num[3])
            {
                return 1;
            }
            //2
            else if (Num[4] == Num[5] && Num[5] == Num[6])
            {
                return 1;
            }
            //3
            else if (Num[6] == Num[7] && Num[7] == Num[8])
            {
                return 1;
            }
            //Winning Condition Vertical
            //1
            else if (Num[1] == Num[4] && Num[4] == Num[7])
            {
                return 1;
            }
            //2
            else if (Num[2] == Num[5] && Num[5] == Num[8])
            {
                return 1;
            }
            //3
            else if (Num[3] == Num[6] && Num[6] == Num[9])
            {
                return 1;
            }
            //Winning Condition Diagonally
            //1
            else if (Num[1] == Num[5] && Num[5] == Num[9])
            {
                return 1;
            }
            //2
            else if (Num[3] == Num[5] && Num[5] == Num[7])
            {
                return 1;
            }
            //All cell is marked return value -1, which resulted in draw
            else if (Num[1] != '1' && Num[2] != '2' && Num[3] != '3' && Num[4] != '4' && Num[5] != '5' && Num[6] != '6' && Num[7] != '7' && Num[8] != '8' && Num[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
    
