using System;
using System.Linq;

namespace Robot
{
    class GetInstr
    {
        public int[] GetDim(string instr)
        {
            int[] x = null;
            try
            {
                x = instr.Split(' ').Select(int.Parse).ToArray();
                foreach(int d in x)
                {
                    if (d <= 0)
                    {
                        Console.WriteLine("Dimensions cannot be negative or 0. \nApplication will close now.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                return x;
            }
            catch (FormatException)
            {
                Console.WriteLine("Forbidden symbol in arena dimensions.");
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error in given dimensions.");
            }
            finally
            {
                if(x == null)
                {
                    Console.WriteLine("Application will close now.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            return x;
        }

        public string[] GetPos(string instr)
        {
            string[] p = instr.Split(' ').ToArray();
            
            return p;
        }

        public string[] GetMove(string instr)
        {
            string[] m = instr.Split(' ').ToArray();

            return m;
        }
    }
}
