using InOut.Utils;
using InOutTest.Ex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InOutTest
{
    
    [TestClass]
    public class JavaScriptSerializerExTest
    {

        private AliasItem aliasItem;
        private string json;
        [TestInitialize]
        public void Setup()
        {
            aliasItem = new AliasItem
            {
                ProperyA = "A",
                PropertyB = true,
                PropretyC = 10L,
            };
            json = "{\"property_a\":\"A\",\"property_b\":true,\"properetyc\":10}";
        }

        [TestMethod]
        public void TestSerialize()
        {
            var jsonConverter = new JavaScriptSerializerEx();
            string result = jsonConverter.Serialize(aliasItem);
            Assert.AreEqual(result, json);
        }

        [TestMethod]
        public void TestDeserialize()
        {
            var jsonConvert = new JavaScriptSerializerEx();
            var item = jsonConvert.Deserialize<AliasItem>(json);
            Assert.AreEqual( aliasItem.ProperyA ,item.ProperyA);
            Assert.AreEqual(aliasItem.PropertyB, item.PropertyB);
            Assert.AreEqual(aliasItem.PropretyC, item.PropretyC);

        }
    }
    
}
