using System;
using System.IO;

class GameMechanics
{
    public string player;
    public string player1;
    public string player2;
    public static string[] arr = new string[9];
    public static int counter = 0;
    public static string winner = "";
    public static bool win = false;
    public GameMechanics(string player1, string player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        player = player1;

    }
    public void startgame()
    {
        while (counter < 9 && win == false)
        {

            GameMoves();

            displayBoard();
            Wincheacker();
            if (win)
            {

                break;
            }
            changeplayer();
            counter++;
        }
        Gameover();
        return;
    }
    public void changeplayer()
    {
        if (!win)
        {
            if (player == player1)
            {
                player = player2;
            }
            else if (player == player2)
            {
                player = player1;
            }
        }

    }
    public void Gameover()
    {
        try
        {
            if (!File.Exists("record.txt"))
            {
                using (StreamWriter sr = new StreamWriter("record.txt"))
                {
                    sr.Close();
                }

            }

            if (!win)
            {
                StreamWriter sw = File.AppendText("record.txt");
                sw.WriteLine(player1 + ",draw;" + player2);
                sw.Close();
                Console.WriteLine("no winner both play draw the game");
            }
            else
            {
                if (winner == player1)
                {
                    StreamWriter sw = File.AppendText("record.txt");
                    sw.WriteLine(player1 + ",win;" + player2);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.AppendText("record.txt");
                    sw.WriteLine(player2 + ",win;" + player1);
                    sw.Close();
                }

                Console.WriteLine(winner + " winns");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        Console.WriteLine("the game is recorded");

        Console.WriteLine("Game over!!!!");
    }
    public void GameMoves()
    {

        int num;

        Console.WriteLine("\n\n" + player + "'s move");
        while (!(int.TryParse(Console.ReadLine(), out num) && num <= 10 && arr[num - 1] == null))
        {
            Console.WriteLine("wrong entry try again.");
        }

        if (player == player1)
        {
            arr[num - 1] = "x";
        }
        else if (player == player2)
        {
            arr[num - 1] = "o";
        }

    }
    public void Wincheacker()
    {
        string currentplayer = "";
        if (player == player1)
        {
            currentplayer = "x";
        }
        else if (player == player2)
        {
            currentplayer = "o";
        }
        if ((arr[0] == currentplayer && arr[1] == currentplayer && arr[2] == currentplayer) || (arr[1] == currentplayer && arr[4] == currentplayer && arr[7] == currentplayer))
        {
            win = true;
            winner = player;
        }


        else if ((arr[0] == currentplayer && arr[3] == currentplayer && arr[6] == currentplayer) || (arr[3] == currentplayer && arr[4] == currentplayer && arr[5] == currentplayer))
        {
            win = true;
            winner = player;
        }
        else if ((arr[2] == currentplayer && arr[5] == currentplayer && arr[8] == currentplayer) || (arr[6] == currentplayer && arr[7] == currentplayer && arr[8] == currentplayer))
        {
            win = true;
            winner = player;

        }
        else if ((arr[0] == currentplayer && arr[4] == currentplayer && arr[8] == currentplayer) || (arr[2] == currentplayer && arr[4] == currentplayer && arr[6] == currentplayer))
        {
            win = true;
            winner = player;
        }


    }
    public static void displayBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            if ((i == 1) || (i == 4) || (i == 7))
            {
                Console.Write(" ");
            }
            Console.Write(arr[i] + " ");
            if (arr[i] == null)
            {
                Console.Write(" ");
            }
            if ((i == 2) || (i == 5) || (i == 8))
            {
                Console.WriteLine();
            }
            if ((i == 2) || (i == 5))
            {
                Console.WriteLine("_ + _ + _");
            }
            if ((i == 0) || (i == 1) || (i == 3) || (i == 4) || (i == 6) || (i == 7))
            {
                Console.Write("|");
            }
        }
    }

}
