using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TDD
{
    [TestClass]
    public class GetInstrTest
    {
        [TestMethod]
        public void GetDimTest()
        {
            int[] expected = { 5, 4, 2 };
            string instr = "5 4 2";
            int[] actual = instr.Split(' ').Select(int.Parse).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPosTest()
        {
            string[] expected = { "2", "4", "N" };
            string instr = "2 4 N";
            string[] actual = instr.Split(' ').ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMoveTest()
        {
            string[] expected = { "F", "F", "L", "R", "B" };
            string instr = "F F L R B";
            string[] actual = instr.Split(' ').ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
