using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OMS.Models.Base;

namespace UnitTests
{
    [TestClass]
    public class ElectronicComponentsType
    {
        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            int id = 1;
            string name = "Resistor";

            var componentType = new ElectronicComponentsTypes(id, name);

            Assert.IsNotNull(componentType);
            Assert.AreEqual(id, componentType.Id);
            Assert.AreEqual(name, componentType.Name);
        }

        [TestMethod]
        public void GetFormattedHeader_ReturnsFormattedString()
        {
            string expectedHeader = "ID  |NAME    ";

            string formattedHeader = ElectronicComponentsTypes.GetFormattedHeader();

            Assert.AreEqual(expectedHeader, formattedHeader);
        }

        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            var componentType = new ElectronicComponentsTypes(1, "Resistor");
            string expectedString = "1   |Resistor";

            string resultString = componentType.ToString();

            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Constructor_NegativeId_ThrowsArgumentException()
        {
            int invalidId = -1;
            string name = "Resistor";

            Assert.ThrowsException<ArgumentException>(() => new ElectronicComponentsTypes(invalidId, name));
        }

        [TestMethod]
        public void Constructor_NullName_ThrowsArgumentException()
        {
            int id = 1;
            string invalidName = null;

            Assert.ThrowsException<ArgumentException>(() => new ElectronicComponentsTypes(id, invalidName));
        }
    }
}
