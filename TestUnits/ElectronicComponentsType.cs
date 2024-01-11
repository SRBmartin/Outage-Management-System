using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OMS.Models.Base;

namespace TestUnits
{
    [TestFixture]
    class ElectronicComponentsType
    {
        [Test]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            int id = 1;
            string name = "Resistor";

            var componentType = new ElectronicComponentsTypes(id, name);

            if(Assert.Equals(componentType, null))
            {
                Assert.Fail("Cannot be null.");
            }
            Assert.Equals(id, componentType.Id);
            Assert.Equals(name, componentType.Name);
        }

        [Test]
        public void GetFormattedHeader_ReturnsFormattedString()
        {
            string expectedHeader = "ID  |NAME    ";

            string formattedHeader = ElectronicComponentsTypes.GetFormattedHeader();

            Assert.Equals(expectedHeader, formattedHeader);
        }

        [Test]
        public void ToString_ReturnsFormattedString()
        {
            var componentType = new ElectronicComponentsTypes(1, "Resistor");
            string expectedString = "1   |Resistor";

            string resultString = componentType.ToString();

            Assert.Equals(expectedString, resultString);
        }

        [Test]
        public void Constructor_NegativeId_ThrowsArgumentException()
        {
            int invalidId = -1;
            string name = "Resistor";

            Assert.Throws<ArgumentException>(() => new ElectronicComponentsTypes(invalidId, name));
        }

        [Test]
        public void Constructor_NullName_ThrowsArgumentNullException()
        {
            int id = 1;
            string invalidName = null;

            Assert.Throws<ArgumentNullException>(() => new ElectronicComponentsTypes(id, invalidName));
        }
    }
}
