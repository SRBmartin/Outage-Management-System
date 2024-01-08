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
    class FaultActions
    {
        [Test]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";

            var faultAction = new FaultAction(id, timeOfAction, description);

            if(Assert.Equals(faultAction, null))
            {
                Assert.Fail("Cannot be null.");
            }
            Assert.Equals(id, faultAction.Id);
            Assert.Equals(timeOfAction.ToString(), faultAction.TimeOfActionS);
            Assert.Equals(description, faultAction.Description);
        }

        [Test]
        public void Constructor_WithFaultId_CreatesInstance()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";
            string fId = "Fault123";

            var faultAction = new FaultAction(id, timeOfAction, description, fId);

            if(Assert.Equals(faultAction, null))
            {
                Assert.Fail("Cannot be null.");
            }
            Assert.Equals(id, faultAction.Id);
            Assert.Equals(timeOfAction.ToString(), faultAction.TimeOfActionS);
            Assert.Equals(description, faultAction.Description);
            Assert.Equals(fId, faultAction.FId);
        }

        [Test]
        public void Constructor_NegativeId_ThrowsArgumentException()
        {
            int invalidId = -1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";

            Assert.Throws<ArgumentException>(() => new FaultAction(invalidId, timeOfAction, description));
        }

        [Test]
        public void Constructor_NullDescription_ThrowsArgumentNullException()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string invalidDescription = null;

            Assert.Throws<ArgumentNullException>(() => new FaultAction(id, timeOfAction, invalidDescription));
        }

        [Test]
        public void ValidTest()
        {
            int id = 1;
            DateTime timeOfAction = DateTime.Now;
            string description = "Performed action";

            var faultAction = new FaultAction(id, timeOfAction, description);

            if(Assert.Equals(faultAction, null))
            {
                Assert.Fail("Cannot be null.");
            }
            Assert.Equals(id, faultAction.Id);
            Assert.Equals(timeOfAction.ToString(), faultAction.TimeOfActionS);
            Assert.Equals(description, faultAction.Description);
        }
    }
}
