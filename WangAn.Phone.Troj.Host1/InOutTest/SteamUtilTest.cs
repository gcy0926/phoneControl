using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using InOut;
using InOut.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InOutTest
{
    /// <summary>
    /// SteamUtilTest 的摘要说明
    /// </summary>
    [TestClass]
    public class SteamUtilTest
    {
        [TestMethod]
        public void TestInt32()
        {
            var m = new MemoryStream(4);
            m.WriteInt32(int.MaxValue);
            m.Position = 0;
            Assert.AreEqual(int.MaxValue, m.ReadInt32());  
        }

        [TestMethod]
        public void TestInt64()
        {
            var m = new MemoryStream(8);
            m.WriteInt64(long.MaxValue);
            m.Position = 0;
            Assert.AreEqual(long.MaxValue, m.ReadInt64());

        }
    }
}
