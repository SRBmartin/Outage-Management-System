using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Classes.DatabaseHandlerClasses;
using OMS.Models.Base;
using OMS.Services;
using System.Data;
using System.Transactions;

namespace UnitTests
{
    [TestClass]
    public class ReportedFaultServices
    {
        [TestMethod]
        public void FindByDateRange_ReturnsCorrectData()
        {
            var startDateStr = DateTime.Parse("2023-01-01").ToString("yyyy-MM-dd");
            var startDate = DateTime.Parse("2023-01-01");
            var endDateStr = DateTime.Parse("2024-01-31").ToString("yyyy-MM-dd");
            var endDate = DateTime.Parse("2024-01-31");
            string cmd = $@"SELECT fid, date_of_fault, fstatus, fshort_desc, ecid, fdesc
                    FROM reported_faults_test
                    WHERE date_of_fault BETWEEN '{startDateStr}' AND '{endDateStr}'";
            var expectedCount = 2;

            using (var scope = new TransactionScope())
            {
                var mockConnection = new Mock<IDbConnection>();

                var mockCommand = new Mock<IDbCommand>();
                mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
                mockCommand.SetupProperty(c => c.CommandText);
                mockCommand.Setup(c => c.ExecuteReader()).Returns(() =>
                {
                    mockCommand.Object.CommandText = cmd;

                    var mockReader = new Mock<IDataReader>();

                    mockReader.SetupSequence(r => r.Read())
                        .Returns(true)  
                        .Returns(true); 
                                        

                    mockReader.Setup(r => r.GetString(0)).Returns("Wires disconnected.");
                    mockReader.Setup(r => r.GetString(1)).Returns(startDateStr); 
                    mockReader.Setup(r => r.GetString(2)).Returns("Unconfirmed");
                    mockReader.Setup(r => r.GetString(3)).Returns("Due to the storm, the wires have disconnected from the circuit.");
                    mockReader.Setup(r => r.GetInt32(4)).Returns(1);
                    mockReader.Setup(r => r.GetString(5)).Returns("Details for the first fault.");

                    mockReader.Setup(r => r.GetString(0)).Returns("Resistor broke down.");
                    mockReader.Setup(r => r.GetString(1)).Returns(endDateStr); 
                    mockReader.Setup(r => r.GetString(2)).Returns("Unconfirmed");
                    mockReader.Setup(r => r.GetString(3)).Returns("Due to high voltage, the resistor burnt down.");
                    mockReader.Setup(r => r.GetInt32(4)).Returns(2);
                    mockReader.Setup(r => r.GetString(5)).Returns("Details for the second fault.");

                    return mockReader.Object;
                });

                var result = ReportedFaultService.FindByDateRange(startDate, endDate, mockConnection.Object);

                Assert.IsNotNull(result);
                Assert.AreEqual(expectedCount, result.Count);


            }
        }
    }
}
