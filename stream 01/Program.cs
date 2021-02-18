using System;

namespace stream_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("wellcome to Tic Tac Toi Game");
            Program p = new Program();

            p.Gamecaller();
        }
        public void Gamecaller()
        {
            string menu;

            Console.WriteLine(@"         
                                          1. New Game
                                          2. About authore
                                          3. stat
                                          4. exite");
            menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    Console.WriteLine("player1 write your name");
                    String player1 = Console.ReadLine();
                    Console.WriteLine("player2 write your name");
                    String player2 = Console.ReadLine();
                    GameMechanics game = new GameMechanics(player1, player2);

                    game.startgame();
                    break;
                case "2":
                    Console.WriteLine("Hermela kebede is the 1st year student at WSB university in poznan in 2020");
                    break;

                case "3":
                    string choice;
                    Console.WriteLine(@"
                                        choose 
                                               1. for One player
                                               2. for Two player");
                    choice = Console.ReadLine();
                    Stats stat = new Stats();
                    switch (choice)
                    {
                        case "1":

                            Console.WriteLine("write the user name you wants to see the stat");
                            string player = Console.ReadLine();
                            stat.OnePlayer(player);
                            break;
                        case "2":

                            Console.WriteLine("insert first player username");
                            string statplayer1 = Console.ReadLine();
                            Console.WriteLine("insert second player usernameyyu");
                            string statplayer2 = Console.ReadLine();
                            stat.TwoPlayer(statplayer1, statplayer2);
                            break;
                        default:
                            Console.WriteLine("wrong entry try again");
                            break;
                    }
                    break;
                case "4":

                    Console.WriteLine("you have successfully Quit the game");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("wrong entry try again");
                    break;

            }
            Gamecaller();

        }

    }


}