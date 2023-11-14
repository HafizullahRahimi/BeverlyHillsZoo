using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BeverlyHillsZoo.Test.Service
{
    [TestClass]
    public class VisitorServiceTests
    {
        [TestMethod]
        public void GetAll_Test()
        {
            IQueryable<Visitor> visitors = new List<Visitor>
            {
                new Visitor()
                {
                    Id = 1,
                    Name = "William",
                    PersonNumber = 1343434

                },
                new Visitor()
                {
                    Id = 2,
                    Name = "Ali",
                    PersonNumber = 5995948

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Provider).Returns(visitors.Provider);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(visitors.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(visitors.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(visitors.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            var actual = service.GetAll();

            // Assert (expected,actual)
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("William", actual.First().Name);

        }

        [TestMethod]
        public void GetById_Test()
        {
            IQueryable<Visitor> visitors = new List<Visitor>
            {
                new Visitor()
                {
                    Id = 1,
                    Name = "William",
                    PersonNumber = 1343434

                },
                new Visitor()
                {
                    Id = 2,
                    Name = "Ali",
                    PersonNumber = 5995948

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Provider).Returns(visitors.Provider);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(visitors.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(visitors.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(visitors.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            var actual = service.GetById(1);

            // Assert (expected,actual)
            Assert.AreEqual("William", actual.Name);

        }

        [TestMethod]
        public void Insert_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Visitor>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            service.Insert(new Visitor()
            {
                Id = 1,
                Name = "William",
                PersonNumber = 1343434
            });

            // Assert (expected,actual)
            mockSet.Verify(m => m.Add(It.IsAny<Visitor>()), Times.Once);

        }

        [TestMethod]
        public void Update_Test()
        {
            IQueryable<Visitor> visitors = new List<Visitor>
            {
                new Visitor()
                {
                    Id = 2,
                    Name = "Ali",
                    PersonNumber = 5995948

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Provider).Returns(visitors.Provider);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(visitors.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(visitors.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(visitors.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            var actual = service.Update(new Visitor()
            {
                Id = 2,
                Name = "William",
                PersonNumber = 300000

            });

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Save_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Visitor>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);

            service.Save();


            // Assert (expected,actual)
            mockContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [TestMethod]
        public void Delete_Test()
        {
            IQueryable<Visitor> visitors = new List<Visitor>
            {
                new Visitor()
                {
                    Id = 2,
                    Name = "Ali",
                    PersonNumber = 5995948

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Provider).Returns(visitors.Provider);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(visitors.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(visitors.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(visitors.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            var actual = service.Delete(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }


        [TestMethod]
        public void Enable_Test()
        {
            IQueryable<Visitor> visitors = new List<Visitor>
            {
                new Visitor()
                {
                    Id = 2,
                    Name = "Ali",
                    PersonNumber = 5995948,
                    IsDeleted = true,

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Provider).Returns(visitors.Provider);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(visitors.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(visitors.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(visitors.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            var actual = service.Enable(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void HaveVisitor_Test()
        {
            IQueryable<Visitor> visitors = new List<Visitor>
            {
                new Visitor()
                {
                    Id = 1,
                    Name = "William",
                    PersonNumber = 200011234000

                },
                new Visitor()
                {
                    Id = 2,
                    Name = "Ali",
                    PersonNumber = 199803025676

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Provider).Returns(visitors.Provider);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(visitors.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(visitors.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(visitors.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Visitors).Returns(mockSet.Object);

            //Act
            var service = new VisitorService(mockContext.Object);
            var actual = service.HaveVisitor(199803025676);

            // Assert (expected,actual)
            Assert.AreEqual(2, actual);

        }
    }
}
