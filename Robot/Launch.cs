using System;
using System.Linq;

namespace Robot
{
    class Launch
    {
        public void checkData(int[] dim, int[] pos, string dir, string[] moveSet)
        {
            for(int i = 0; i <= 1; i++)
            {
                if (dim[i] < pos[i] && pos[i] > 0)
                {
                    Console.WriteLine("Wrong robot position");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            if (dir.Length != 1)
            {
                Console.WriteLine(String.Format("{0} is a wrong format of robot direction.\nApplication will close now.", dir));
                Console.ReadKey();
                Environment.Exit(0);
            }
            foreach (string move in moveSet)
            {
                if (move.Length != 1)
                {
                    Console.WriteLine(String.Format("{0} is a wrong format of robot move command.\nApplication will close now.", move));
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

        public string[] Move(int[] dim, int[] pos, string dir, string[] moveSet)
        {
            var moveTo = new MoveDirection();
            string[] zmienna = { "", "" };
            foreach(string move in moveSet)
            {
                switch (dir)
                {
                    case "N":
                        zmienna = moveTo.Moving(dim, pos, move, dir);
                    break;

                    case "S":
                        zmienna = moveTo.Moving(dim, pos, move, dir);
                        break;

                    case "E":
                        zmienna = moveTo.Moving(dim, pos, move, dir);
                        break;

                    case "W":
                        zmienna = moveTo.Moving(dim, pos, move, dir);
                        break;
                    default:
                    break;
                }
                if (String.Equals(dir, "N") || String.Equals(dir, "S"))
                {
                    pos[0] = Int32.Parse(zmienna[0]);
                    dir = zmienna[1];
                }
                else
                {
                    pos[1] = Int32.Parse(zmienna[0]);
                    dir = zmienna[1];
                }
            }

            string[] finalPosition = { pos[0].ToString(), pos[1].ToString(), dir };

            return finalPosition;
        }
    }
}
