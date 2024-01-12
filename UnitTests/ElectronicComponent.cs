using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OMS.Models.Base;

namespace UnitTests
{
    [TestClass]
    public class ElectronicComponent
    {
        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            int id = 1;
            string name = "Component1";
            ElectronicComponentsTypes type = new ElectronicComponentsTypes(1, "Type1");
            int x = 10;
            int y = 20;
            string voltageLevel = "low voltage";

            var component = new ElectronicComponents(id, name, type, x, y, voltageLevel);

            Assert.IsNotNull(component);
            Assert.AreEqual(id, component.Id);
            Assert.AreEqual(name, component.Name);
            Assert.AreEqual(type, component.Type);
            Assert.AreEqual(x, component.X);
            Assert.AreEqual(y, component.Y);
            Assert.AreEqual(voltageLevel, component.Voltage_level);
        }

        [DataRow(-4, "Component1", "Type1", 10, 20, "low voltage")]
        [DataRow(2, "Component2", null, 10, 20, "low voltage")]
        [DataRow(5, "Component5", "Type5", 10, 20, "invalid voltage")]
        [DataTestMethod]
        public void Constructor_InvalidParameters_ThrowsArgumentException(int id, string name, string typeName, int x, int y, string voltageLevel)
        {
            ElectronicComponentsTypes type = typeName != null ? new ElectronicComponentsTypes(1, typeName) : null;

            Assert.ThrowsException<ArgumentException>(() => new ElectronicComponents(id, name, type, x, y, voltageLevel));
        }


        [TestMethod]
        public void GetFormattedHeader_ReturnsCorrectString()
        {
            var header = ElectronicComponents.GetFormattedHeader();

            Assert.AreEqual("ID   | NAME     | [ID|TYPE NAME] | X    | Y    | VOLTAGE LEVEL", header);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            var component = new ElectronicComponents(1, "Wires", new ElectronicComponentsTypes(1, "Wire"), 10, 20, "low voltage");

            var result = component.ToString();

            Assert.AreEqual("1    | Wires    |  [1|Wire]      | 10   | 20   | low voltage", result);
        }
        [TestMethod]
        public void NameField_MaxLength_Overflow_ArgumentException()
        {
            int id = 1;
            string name = new string('A', ElectronicComponents.MAX_NAME_SIZE + 1);
            ElectronicComponentsTypes type = new ElectronicComponentsTypes(1, "Type1");
            int x = 10;
            int y = 20;
            string voltageLevel = "low voltage";

            Assert.ThrowsException<ArgumentException>(() => new ElectronicComponents(id, name, type, x, y, voltageLevel));
        }
    }
}
