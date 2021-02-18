using System;
using System.IO;

namespace stream_01
{

    public class Stats
    {
        public void OnePlayer(string username)
        {
            if (!File.Exists("record.txt"))
            {
                Console.WriteLine("there is no any record at all");
            }
            else
            {
                int count = 0;
                int win = 0;
                using (StreamReader sr = new StreamReader("record.txt"))
                {
                    string reader;

                    while (!sr.EndOfStream)
                    {
                        reader = sr.ReadLine();
                        if (reader.Before(",") == username)
                        {
                            if (reader.Between(",", ";") == "win")
                            {
                                win++;
                            }
                            count++;
                        }
                        else if (reader.After(";") == username)
                        {
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("this person doesn't have a record");
                }
                else
                {
                    float ratio = win / count;
                    Console.WriteLine("the player winning ratio from whole game he played is: " + ratio);
                }
            }
        }
        public void TwoPlayer(string username1, string username2)
        {
            if (!File.Exists("record.txt"))
            {
                Console.WriteLine("there is no any record at all");
            }
            else
            {
                int count1 = 0, count2 = 0;
                int win1 = 0, win2 = 0;

                using (StreamReader sr = new StreamReader("record.txt"))
                {
                    string reader;
                    while (!sr.EndOfStream)
                    {
                        reader = sr.ReadLine();
                        if (reader.Before(",") == username1)
                        {
                            if (reader.Between(",", ";") == "win")
                            {
                                win1++;
                            }
                            count1++;
                        }
                        else if (reader.Before(",") == username2)
                        {
                            if (reader.Between(",", ";") == "win")
                            {
                                win2++;
                            }
                            count2++;
                        }
                        else if (reader.After(";") == username1)
                        {
                            count1++;
                        }
                        else if (reader.After(";") == username2)
                        {
                            count2++;
                        }

                    }
                }

                if (count1 == 0)
                {
                    Console.WriteLine(username1 + " doesn't have a record");
                }
                else if (count2 == 0)
                {
                    Console.WriteLine(username2 + " doesn't have a record");
                }
                else
                {
                    int numberOfgames = count1 + count2;
                    double ratio1 = (float)win1 / numberOfgames;
                    double ratio2 = (float)win2 / numberOfgames;
                    Console.WriteLine("the players have played " + numberOfgames + " games");
                    Console.WriteLine(username1 + " have won " + (ratio1 * 100) + " percent of the games");
                    Console.WriteLine(username2 + " have won " + (ratio2 * 100) + " percent of the games");
                }
            }
        }
    }


}
