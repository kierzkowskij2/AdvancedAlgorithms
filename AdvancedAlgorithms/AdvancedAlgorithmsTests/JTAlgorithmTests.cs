using System;
using System.Collections.Generic;
using AdvancedAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph;

namespace AdvancedAlgorithmsTests
{
    [TestClass]
    public class JTAlgorithmTests
    {
        [TestMethod]
        public void CheckTest1()
        {
            FullJTATest("test1.txt", 5, 5, 4);
        }

        [TestMethod]
        public void CheckTest2()
        {
            FullJTATest("test2.txt", 6, 6, 6);
        }

        [TestMethod]
        public void CheckTest3()
        {
            FullJTATest("test3.txt", 12, 12, 11);
        }

        private void FullJTATest(string fileName, int expectedIterations, int expectede1Count, int expectede2Count)
        {
            UndirectedGraph<int, Edge<int>> g;
            List<Tuple<int, int>> pairs;
            string filePath = TestHelper.FindFilePath(fileName);
            var result = FileParser.TryParseFile(filePath, out g, out pairs);
            var e1 = new List<Tuple<int, int>>();
            var e2 = new List<Tuple<int, int>>();
            int numberOfIterations = JTAlgorithm.Calculate(g, pairs, ref e1, ref e2);
            Assert.AreEqual(expectedIterations, numberOfIterations);
            Assert.AreEqual(expectede1Count, e1.Count);
            Assert.AreEqual(expectede2Count, e2.Count);
        }
    }
}
