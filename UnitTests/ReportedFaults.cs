using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OMS.Models.Base;
namespace UnitTests
{
    [TestClass]
    public class ReportedFaults
    {
        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents(1, "Wires", new ElectronicComponentsTypes(1, "Wire"), 1, 1, "low voltage");
            string description = "Description";
            var reportedFault = new ReportedFault(shortDescription, faultyComponent, description);
            Assert.IsNotNull(reportedFault);
            Assert.AreEqual(shortDescription, reportedFault.Short_description);
            Assert.AreEqual(shortDescription, reportedFault.Short_description);
            Assert.AreEqual(faultyComponent, reportedFault.FaultyComponent);
            Assert.AreEqual(description, reportedFault.Description);
        }
        [TestMethod]
        public void Constructor_NullShortDescription_ThrowsArgumentNullException()
        {
            string shortDescription = null;
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string description = "Description";
            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(shortDescription, faultyComponent, description));
        }
    }
}
