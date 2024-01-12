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
        public void Constructor_NullShortDescription_ThrowsArgumentException()
        {
            string shortDescription = null;
            ElectronicComponents faultyComponent = new ElectronicComponents(1, "Wire", new ElectronicComponentsTypes(1,"Wires"),1,2,"low voltage");
            string description = "Description";
            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(shortDescription, faultyComponent, description));
        }
        [TestMethod]
        public void Constructor_NullFaultyComponent_ThrowsArgumentException()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = null;
            string description = "Description";

            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(shortDescription, faultyComponent, description));
        }
        [TestMethod]
        public void ShortDescription_SetToEmptyString_ThrowsArgumentException()
        {
            string emptyShortDescription = string.Empty;
            ElectronicComponents faultyComponent = new ElectronicComponents(1, "Wire", new ElectronicComponentsTypes(1, "Wires"), 1, 2, "low voltage");
            string description = "Description";

            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(emptyShortDescription, faultyComponent, description));
        }
        [TestMethod]
        public void Description_SetToNull_ThrowsArgumentException()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents(1, "Wire", new ElectronicComponentsTypes(1, "Wires"), 1, 2, "low voltage");
            string nullDescription = null;

            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(shortDescription, faultyComponent, nullDescription));
        }
        [TestMethod]
        public void Id_SetValue_IdPropertyMatches()
        {
            var reportedFault = new ReportedFault("Fault", new ElectronicComponents(1, "Wire", new ElectronicComponentsTypes(1, "Wires"), 1, 2, "low voltage"), "Description");
            string newId = "NewId";

            reportedFault.Id = newId;

            Assert.AreEqual(newId, reportedFault.Id);
        }

        [TestMethod]
        public void ShortDescription_ExceedsMaxLength_ThrowsArgumentException()
        {
            string longShortDescription = new string('A', ReportedFault.MAX_SHORT_DESCRIPTION + 1);
            ElectronicComponents faultyComponent = new ElectronicComponents(1, "Wire", new ElectronicComponentsTypes(1, "Wires"), 1, 2, "low voltage");
            string description = "Description";

            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(longShortDescription, faultyComponent, description));
        }

        [TestMethod]
        public void Description_ExceedsMaxLength_ThrowsArgumentException()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents(1, "Wire", new ElectronicComponentsTypes(1, "Wires"), 1, 2, "low voltage");
            string longDescription = new string('B', ReportedFault.MAX_DESCRIPTION + 1);

            Assert.ThrowsException<ArgumentException>(() => new ReportedFault(shortDescription, faultyComponent, longDescription));
        }
    }
}
