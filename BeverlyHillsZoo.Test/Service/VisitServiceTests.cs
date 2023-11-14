using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BeverlyHillsZoo.Test.Service
{
    [TestClass]
    public class VisitServiceTests
    {
        [TestMethod]
        public void GetAll_Test()
        {
            IQueryable<Visit> visits = new List<Visit>
            {
                new Visit()
                {
                    Id = 1,
                    NumberOfVisitor = 1,
                    VisitDate = DateTime.Now.Date,
                    AtMorning = true,
                    AtAfternoon = false,
                    AnimalId = 1,
                    VisitorId = 1,
            

                },
                new Visit()
                {
                    Id = 2,
                    NumberOfVisitor = 1,
                    VisitDate = DateTime.Now.Date,
                    AtMorning = false,
                    AtAfternoon = true,
                    AnimalId = 1,
                    VisitorId = 2,
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visit>>();
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Provider).Returns(visits.Provider);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Expression).Returns(visits.Expression);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.ElementType).Returns(visits.ElementType);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.GetEnumerator()).Returns(visits.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visits).Returns(mockSet.Object);

            //Act
            var service = new VisitService(mockContext.Object);
            var actual = service.GetAll();

            // Assert (expected,actual)
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(1, actual.First().Id);

        }

        [TestMethod]
        public void GetById_Test()
        {
            IQueryable<Visit> visits = new List<Visit>
            {
                new Visit()
                {
                    Id = 1,
                    NumberOfVisitor = 1,
                    VisitDate = DateTime.Now.Date,
                    AtMorning = true,
                    AtAfternoon = false,
                    AnimalId = 1,
                    VisitorId = 30,


                },
                new Visit()
                {
                    Id = 2,
                    NumberOfVisitor = 1,
                    VisitDate = DateTime.Now.Date,
                    AtMorning = false,
                    AtAfternoon = true,
                    AnimalId = 1,
                    VisitorId = 2,
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visit>>();
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Provider).Returns(visits.Provider);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Expression).Returns(visits.Expression);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.ElementType).Returns(visits.ElementType);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.GetEnumerator()).Returns(visits.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visits).Returns(mockSet.Object);

            //Act
            var service = new VisitService(mockContext.Object);
            var actual = service.GetById(1);

            // Assert (expected,actual)
            Assert.AreEqual(30, actual.VisitorId);

        }

        [TestMethod]
        public void Insert_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Visit>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visits).Returns(mockSet.Object);

            //Act
            var service = new VisitService(mockContext.Object);
            service.Insert(new Visit()
            {
                Id = 1,
                NumberOfVisitor = 1,
                VisitDate = DateTime.Now.Date,
                AtMorning = true,
                AtAfternoon = false,
                AnimalId = 1,
                VisitorId = 1,
            });

            // Assert (expected,actual)
            mockSet.Verify(m => m.Add(It.IsAny<Visit>()), Times.Once);

        }

        [TestMethod]
        public void Update_Test()
        {
            IQueryable<Visit> visits = new List<Visit>
            {
                new Visit()
                {
                    Id = 1,
                    NumberOfVisitor = 1,
                    VisitDate = DateTime.Now.Date,
                    AtMorning = true,
                    AtAfternoon = false,
                    AnimalId = 1,
                    VisitorId = 70
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visit>>();
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Provider).Returns(visits.Provider);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Expression).Returns(visits.Expression);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.ElementType).Returns(visits.ElementType);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.GetEnumerator()).Returns(visits.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visits).Returns(mockSet.Object);

            //Act
            var service = new VisitService(mockContext.Object);
            var actual = service.Update(new Visit()
            {
                Id = 1,
                NumberOfVisitor = 1,
                VisitDate = DateTime.Now.Date,
                AtMorning = true,
                AtAfternoon = false,
                AnimalId = 1,
                VisitorId = 5

            });

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Save_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Visit>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visits).Returns(mockSet.Object);

            //Act
            var service = new VisitService(mockContext.Object);

            service.Save();


            // Assert (expected,actual)
            mockContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [TestMethod]
        public void Delete_Test()
        {
            IQueryable<Visit> visits = new List<Visit>
            {

                new Visit()
                {
                    Id = 2,
                    NumberOfVisitor = 1,
                    VisitDate = DateTime.Now.Date,
                    AtMorning = false,
                    AtAfternoon = true,
                    AnimalId = 1,
                    VisitorId = 2,
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visit>>();
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Provider).Returns(visits.Provider);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.Expression).Returns(visits.Expression);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.ElementType).Returns(visits.ElementType);
            mockSet.As<IQueryable<Visit>>().Setup(m => m.GetEnumerator()).Returns(visits.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visits).Returns(mockSet.Object);

            //Act
            var service = new VisitService(mockContext.Object);
            var actual = service.Delete(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

    }
}
