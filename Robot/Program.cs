using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data, moveSet;
            int[] dim, pos = { -1, -1 };
            string dir;
            var rf = new ReadFile();
            var instr = new GetInstr();
            var start = new Launch();

            data = rf.ReadingFile();

            dim = instr.GetDim(data[0]);
            for(int i=0; i <= 1; i++)
            {
                try
                {
                    pos[i] = int.Parse(instr.GetPos(data[1])[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Forbidden symbol in robot position.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected error in given position.");
                }
                finally
                {
                    if (pos[i] < 0 )
                    {
                        Console.WriteLine("Position cannot be negative.\nApplication will close now.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }

            dir = instr.GetPos(data[1])[2].ToUpper();
            moveSet = instr.GetMove(data[2]);

            start.checkData(dim, pos, dir, moveSet);
            data = start.Move(dim, pos, dir, moveSet);

            Console.WriteLine(String.Format("Robot has stopped at position ({0},{1}), and he is turned to {2}.", data[0], data[1], data[2]));

            Console.ReadKey();
        }
    }
}
