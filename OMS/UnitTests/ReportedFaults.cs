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
    class ReportedFaults
    {
        [Test]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string description = "Description";

            var reportedFault = new ReportedFault(shortDescription, faultyComponent, description);

            if(Assert.Equals(reportedFault, null))
            {
                Assert.Fail("Cannot be null");
            }
            Assert.Equals(shortDescription, reportedFault.Short_description);
            Assert.Equals(faultyComponent, reportedFault.FaultyComponent);
            Assert.Equals(description, reportedFault.Description);
        }

        [Test]
        public void Constructor_NullShortDescription_ThrowsArgumentNullException()
        {
            string shortDescription = null;
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string description = "Description";

            Assert.Throws<ArgumentNullException>(() => new ReportedFault(shortDescription, faultyComponent, description));
        }

        [Test]
        public void Constructor_NullFaultyComponent_ThrowsArgumentNullException()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = null;
            string description = "Description";

            Assert.Throws<ArgumentNullException>(() => new ReportedFault(shortDescription, faultyComponent, description));
        }

        [Test]
        public void ShortDescription_SetToEmptyString_ThrowsArgumentException()
        {
            string emptyShortDescription = string.Empty;
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string description = "Description";

            Assert.Throws<ArgumentException>(() => new ReportedFault(emptyShortDescription, faultyComponent, description));
        }

        [Test]
        public void Description_SetToNull_ThrowsArgumentNullException()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string nullDescription = null;

            Assert.Throws<ArgumentNullException>(() => new ReportedFault(shortDescription, faultyComponent, nullDescription));
        }

        [Test]
        public void Id_SetValue_IdPropertyMatches()
        {
            var reportedFault = new ReportedFault("Fault", new ElectronicComponents(), "Description");
            string newId = "NewId";

            reportedFault.Id = newId;

            Assert.Equals(newId, reportedFault.Id);
        }

        [Test]
        public void Id_SetToNull_ThrowsArgumentNullException()
        {
            var reportedFault = new ReportedFault("Fault", new ElectronicComponents(), "Description");

            Assert.Throws<ArgumentNullException>(() => reportedFault.Id = null);
        }

        [Test]
        public void Id_SetToEmptyString_ThrowsArgumentException()
        {
            var reportedFault = new ReportedFault("Fault", new ElectronicComponents(), "Description");

            Assert.Throws<ArgumentException>(() => reportedFault.Id = string.Empty);
        }

        [Test]
        public void ShortDescription_ExceedsMaxLength_ThrowsArgumentException()
        {
            string longShortDescription = new string('A', ReportedFault.MAX_SHORT_DESCRIPTION + 1);
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string description = "Description";

            Assert.Throws<ArgumentException>(() => new ReportedFault(longShortDescription, faultyComponent, description));
        }

        [Test]
        public void Description_ExceedsMaxLength_ThrowsArgumentException()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string longDescription = new string('B', ReportedFault.MAX_DESCRIPTION + 1);

            Assert.Throws<ArgumentException>(() => new ReportedFault(shortDescription, faultyComponent, longDescription));
        }

        [Test]
        public void ValidTest()
        {
            string shortDescription = "Fault";
            ElectronicComponents faultyComponent = new ElectronicComponents();
            string description = "Description";

            var reportedFault = new ReportedFault(shortDescription, faultyComponent, description);

            if (Assert.Equals(reportedFault, null))
            {
                Assert.Fail("Cannot be null.");
            }
            Assert.Equals(shortDescription, reportedFault.Short_description);
            Assert.Equals(faultyComponent, reportedFault.FaultyComponent);
            Assert.Equals(description, reportedFault.Description);
        }
    }
}
