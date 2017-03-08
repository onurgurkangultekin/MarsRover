using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMarsRover
    {
        Plateau p = new Plateau();

        /// <summary>
        /// Constructor of unit test. Creates a plateau as min:0,0 max:5,5
        /// </summary>
        public UnitTestMarsRover()
        {
            p = new Plateau()
            {
                minX = 0,
                minY = 0,
                maxX = 5,
                maxY = 5
            };
        }


        /// <summary>
        /// Creates first rover and makes it move and compares the result with the actual values.
        /// </summary>
        [TestMethod]
        public void TestMethodFirstRover()
        {
            var rover = new Rover
            {
                X = 1,
                Y = 2,
                D = Direction.N
            };

            var instruction = "LMLMLMLMM";
            foreach (var c in instruction)
            {
                rover.Move(c, p);
            }

            Assert.AreEqual(1, rover.X);
            Assert.AreEqual(3, rover.Y);
            Assert.AreEqual(Direction.N, rover.D);
        }


        /// <summary>
        /// /// Creates second rover and makes it move and compares the result with the actual values.
        /// </summary>
        [TestMethod]
        public void TestMethodSecondRover()
        {
            var rover = new Rover
            {
                X = 3,
                Y = 3,
                D = Direction.E
            };

            var instruction = "MMRMMRMRRM";
            foreach (var c in instruction)
            {
                rover.Move(c, p);
            }

            Assert.AreEqual(5, rover.X);
            Assert.AreEqual(1, rover.Y);
            Assert.AreEqual(Direction.E, rover.D);
        }


        /// <summary>
        /// create a rover on the end points of the plateau and try it move to borders. Expect to throw a user-typed exception named CantMoveException
        /// </summary>
        [TestMethod]
        public void TestMethodCantMoveException()
        {
            var rover = new Rover
            {
                X = 5,
                Y = 5,
                D = Direction.E
            };

            var instruction = "MMMM";

            foreach (var c in instruction)
            {
                Assert.ThrowsException<CantMoveException>(() => rover.Move(c, p));
            }
        }
    }
}
