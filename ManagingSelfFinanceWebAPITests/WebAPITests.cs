using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace ManagingSelfFinanceWebAPITests
{
    [TestClass]
    public class WebAPITests
    {
        [TestMethod]
        public void OperationsServiceTests()
        {
            var options = new DbContextOptions<AppDBContext>();
            var _db = new AppDBContext(options);
            var service = new OperationRepository(_db);
            var expected = new Operation
            {
                Id = 1,
                Name = "job",
                TypeOperation = 1
            };
            var result = service.GetAll();
            var actual = new Operation
            {
                Id = result.First().Id,
                Name = result.First().Name,
                TypeOperation = result.First().TypeOperation
            };
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.TypeOperation, actual.TypeOperation);
        }
        [TestMethod]
        public void RegisterOperationsServiceTest()
        {
            var options = new DbContextOptions<AppDBContext>();
            var _db = new AppDBContext(options);
            var service = new RegisterOperationRepository(_db);
            var expected = new RegisterOperation
            {
                Id = 1,
                Date = new DateTime(2022, 09, 10),
                Amount = 5250,
                OperationId = 1
            };
            var result = service.GetAll();
            var actual = new RegisterOperation
            {
                Id = result.First().Id,
                Date = result.First().Date,
                Amount = result.First().Amount,
                OperationId = result.First().OperationId
            };
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.OperationId, actual.OperationId);
        }
        [TestMethod]
        public void TypeOperationServiceTest()
        {
            var options = new DbContextOptions<AppDBContext>();
            var _db = new AppDBContext(options);
            var service = new TypeOperationRepository(_db);
            var expected = new TypeOperation
            {
                Id = 1,
                Type = "income"
            };
            var result = service.GetAll();
            var actual = new TypeOperation
            {
                Id = result.First().Id,
                Type = result.First().Type
            };
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Type, actual.Type);
        }
        [TestMethod]
        public void ReportServiceTest()
        {
            var options = new DbContextOptions<AppDBContext>();
            var _db = new AppDBContext(options);
            var service = new ReportRepository(_db);
            var startDate = new DateTime(2022, 09, 10);
            var endDate = new DateTime(2022, 09, 15);
            var expected = new Report
            {
                Id = 1,
                Name = "job",
                Amount = 5250,
                Date = new DateTime(2022, 09, 10),
                Type = "income"
            };
            var result = service.SelectDateAsync(startDate, endDate);
            var actual = new Report
            {
                Id = result.First().Id,
                Name = result.First().Name,
                Amount = result.First().Amount,
                Date = result.First().Date,
                Type = result.First().Type
            };
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Type, actual.Type);
        }
    }
}