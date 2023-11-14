using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BeverlyHillsZoo.Test.Service
{
    [TestClass]
    public class GuideServiceTests
    {
        [TestMethod]
        public void GetAll_Test()
        {
            IQueryable<Guide> guides = new List<Guide>
            {
                new Guide()
                {
                    Id = 1,
                    Name = "William",
                    CompetenceType = 1
                },
                new Guide()
                {
                    Id = 2,
                    Name = "Ali",
                    CompetenceType = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Guide>>();
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Provider).Returns(guides.Provider);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Expression).Returns(guides.Expression);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.ElementType).Returns(guides.ElementType);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.GetEnumerator()).Returns(guides.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);
            var actual = service.GetAll();

            // Assert (expected,actual)
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("William", actual.First().Name);

        }

        [TestMethod]
        public void GetById_Test()
        {
            IQueryable<Guide> guides = new List<Guide>
            {
                new Guide()
                {
                    Id = 1,
                    Name = "William",
                    CompetenceType = 1
                },
                new Guide()
                {
                    Id = 2,
                    Name = "Ali",
                    CompetenceType = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Guide>>();
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Provider).Returns(guides.Provider);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Expression).Returns(guides.Expression);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.ElementType).Returns(guides.ElementType);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.GetEnumerator()).Returns(guides.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);
            var actual = service.GetById(1);

            // Assert (expected,actual)
            Assert.AreEqual("William", actual.Name);

        }

        [TestMethod]
        public void Insert_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Guide>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);
            service.Insert(new Guide()
            {
                Id = 1,
                Name = "William",
                CompetenceType = 1
            });

            // Assert (expected,actual)
            mockSet.Verify(m => m.Add(It.IsAny<Guide>()), Times.Once);

        }

        [TestMethod]
        public void Update_Test()
        {
            IQueryable<Guide> guides = new List<Guide>
            {
                new Guide()
                {
                    Id = 1,
                    Name = "William",
                    CompetenceType = 1
                },
                new Guide()
                {
                    Id = 2,
                    Name = "Ali",
                    CompetenceType = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Guide>>();
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Provider).Returns(guides.Provider);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Expression).Returns(guides.Expression);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.ElementType).Returns(guides.ElementType);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.GetEnumerator()).Returns(guides.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);
            var actual = service.Update(new Guide()
            {
                Id = 2,
                Name = "William",
                CompetenceType= 1

            });

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Save_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Guide>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);

            service.Save();


            // Assert (expected,actual)
            mockContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [TestMethod]
        public void Delete_Test()
        {
            IQueryable<Guide> guides = new List<Guide>
            {
                new Guide()
                {
                    Id = 2,
                    Name = "Ali",
                    CompetenceType = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Guide>>();
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Provider).Returns(guides.Provider);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Expression).Returns(guides.Expression);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.ElementType).Returns(guides.ElementType);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.GetEnumerator()).Returns(guides.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);
            var actual = service.Delete(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }


        [TestMethod]
        public void Enable_Test()
        {
            IQueryable<Guide> guides = new List<Guide>
            {
                new Guide()
                {
                    Id = 2,
                    Name = "Ali",
                    CompetenceType = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Guide>>();
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Provider).Returns(guides.Provider);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.Expression).Returns(guides.Expression);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.ElementType).Returns(guides.ElementType);
            mockSet.As<IQueryable<Guide>>().Setup(m => m.GetEnumerator()).Returns(guides.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Guides).Returns(mockSet.Object);

            //Act
            var service = new GuideService(mockContext.Object);
            var actual = service.Enable(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }
    }
}
