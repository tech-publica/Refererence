using System;
using System.Collections.Generic;
using System.Threading;

namespace Refererence.Refe21_Threads.Exes
{
    public enum Color {Pink, Orange, Yellow, Blue, Magenta}
    public class ToiletPaper
    {
        Color color;
        public ToiletPaper(Color c)
        {
            Color = c;
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
    }
    public class BathRoom
    {
        public const int REPETITIONS = 5;
        IList<ToiletPaper> rolls = new List<ToiletPaper>();
        public void addRoll(ToiletPaper paper)
        {
            rolls.Add(paper);

        }
        public ToiletPaper ConsumeRoll()
        {
            ToiletPaper p = null;
            if (rolls[0] != null)
            {
                p = rolls[0];
                rolls.RemoveAt(0);
            }
            return p;
        }

        public bool hasPaper
        {
            get { return rolls.Count > 0; }
        }

    }


    public class BathRoomUser
    {
        BathRoom wc;
        Thread t; 
        public BathRoomUser(BathRoom wc)
        {
            this.wc = wc;
            t = new Thread(run);
            t.Start();
        }

        public void run()
        {
            for (int i = 0; i < BathRoom.REPETITIONS; i++)
            {
                lock (wc)
                {
                    while (! wc.hasPaper)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name +
                          ": Damn! I am out of paper, gotta wait...");

                        Monitor.Wait(wc);
                    }
                    ToiletPaper t = wc.ConsumeRoll();
                    Console.WriteLine(Thread.CurrentThread.Name +
                          ": Aaaaaaaah! Finally I can \"execute\".. and with a " + t.Color + " paper!");
                                                                    
                }
            }
        }

    }
    public class ToiletAssistant
    {
        BathRoom wc;
        Thread t;
        Random random;
        public ToiletAssistant(BathRoom wc)
        {
            this.wc = wc;
            t = new Thread(run);
            random = new Random();
            t.Start();
        }

        public void run()
        {
            for (int i = 0; i < BathRoom.REPETITIONS; i++)
            {
                int time = random.Next(4) + 1;;
                Thread.Sleep(time* 1000);
                ToiletPaper paper = new ToiletPaper((Color) time);
                lock (wc)
                {
                    wc.addRoll(paper);

                    Console.WriteLine(Thread.CurrentThread.Name +
                         ": What a life, all day refilling toilet paper...here is your " +
                         paper.Color + " roll...");

                    Monitor.Pulse(wc);
                }
            }
        }

    }

    public class Test
    {
        static void Main()
        {
            BathRoom wc = new BathRoom();
            BathRoomUser user = new BathRoomUser(wc);
            ToiletAssistant assistant = new ToiletAssistant(wc);
        }
    }


}
