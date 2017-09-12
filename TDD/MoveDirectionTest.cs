using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class MoveDirectionTest
    {
        [TestMethod]
        public void MovingTest()
        {
            int[] dim = { 5, 5 }, pos = { 3, 3 };
            string move = "F", dir = "N";
            string[] expected = { "4", "N" };

            string[] direction = { "N", "E", "S", "W" };
            int j;
            if (String.Equals(direction[0], dir) || String.Equals(direction[2], dir))
            {
                j = 0;
                if (String.Equals(direction[2], dir))
                {
                    pos[j] *= -1;
                }
            }
            else
            {
                j = 1;
                if (String.Equals(direction[3], dir))
                {
                    pos[j] *= -1;
                }
            }
            switch (move.ToUpper())
            {
                case "F":
                    if (dim[j] - pos[j] != 0)
                        pos[j] += 1;
                    else Console.WriteLine("Cannot move here.");
                    break;

                case "B":
                    if (dim[j] - pos[j] != dim[j])
                        pos[j] -= 1;
                    else Console.WriteLine("Cannot move here.");
                    break;

                case "L":
                    for (int i = 0; i <= direction.Length - 1; i++)
                    {
                        if (String.Equals(direction[i], dir))
                        {
                            if (i != 0)
                            {
                                dir = direction[i - 1];
                                break;
                            }
                            else
                            {
                                dir = direction[3];
                                break;
                            }
                        }
                    }
                    break;

                case "R":
                    for (int i = 0; i <= direction.Length - 1; i++)
                    {
                        if (String.Equals(direction[i], dir))
                        {
                            if (i != 3)
                            {
                                dir = direction[i + 1];
                                break;
                            }
                            else
                            {
                                dir = direction[0];
                                break;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }

            string[] actual = { pos[j].ToString(), dir };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
