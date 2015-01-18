using System;
using InOut;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InOutTest
{
    [TestClass]
    public class ProtocolTest
    {
        [TestMethod]
        public void TestDataHeaderGenerator()
        {
            var result = Protocol.DataHeaderGenerator(int.MaxValue, 1, false, short.MaxValue, 1);

            var expect = new Byte[] { 127, 255, 255, 255, 0, 0, 0, 1, 0, 127, 255, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(expect, result);

        }
    }
}
