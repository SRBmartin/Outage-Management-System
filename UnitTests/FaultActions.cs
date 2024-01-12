using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OMS.Models.Base;

namespace UnitTests
{
    [TestClass]
    public class FaultActions
    {
        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";

            var faultAction = new FaultAction(id, timeOfAction, description);

            Assert.IsNotNull(faultAction);
            Assert.AreEqual(id, faultAction.Id);
            Assert.AreEqual(timeOfAction, faultAction.TimeOfAction);
            Assert.AreEqual(description, faultAction.Description);
        }

        [TestMethod]
        public void Constructor_WithFaultId_CreatesInstance()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";
            string fId = "20240111114615_1";

            var faultAction = new FaultAction(id, timeOfAction, description, fId);

            Assert.IsNotNull(faultAction);
            Assert.AreEqual(id, faultAction.Id);
            Assert.AreEqual(timeOfAction, faultAction.TimeOfAction);
            Assert.AreEqual(description, faultAction.Description);
            Assert.AreEqual(fId, faultAction.FId);
        }

        [TestMethod]
        public void Constructor_NegativeId_ThrowsArgumentException()
        {
            int invalidId = -1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";

            Assert.ThrowsException<ArgumentException>(() => new FaultAction(invalidId, timeOfAction, description));
        }

        [TestMethod]
        public void Constructor_NullDescription_ThrowsArgumentException()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string invalidDescription = null;

            Assert.ThrowsException<ArgumentException>(() => new FaultAction(id, timeOfAction, invalidDescription));
        }

    }
}
