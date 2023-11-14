using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BeverlyHillsZoo.Test.Service
{
    [TestClass]
    public class HabitatAirServiceTests
    {
        [TestMethod]
        public void GetAll_Test()
        {
            IQueryable<HabitatAir> habitatAirs = new List<HabitatAir>
            {
                new HabitatAir()
                {
                    Id = 1,
                    Name = "Colugos",
                    Type = 1,
                    MaxAltitude = 345

                },
                new HabitatAir()
                {
                    Id = 2,
                    Name = "Flying Fish",
                    Type = 1,
                    MaxAltitude = 500

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<HabitatAir>>();
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Provider).Returns(habitatAirs.Provider);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Expression).Returns(habitatAirs.Expression);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.ElementType).Returns(habitatAirs.ElementType);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.GetEnumerator()).Returns(habitatAirs.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            var actual = service.GetAll();

            // Assert (expected,actual)
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("Colugos", actual.First().Name);

        }

        [TestMethod]
        public void GetById_Test()
        {
            IQueryable<HabitatAir> habitatAirs = new List<HabitatAir>
            {
                new HabitatAir()
                {
                    Id = 1,
                    Name = "Colugos",
                    Type = 1,
                    MaxAltitude = 345

                },
                new HabitatAir()
                {
                    Id = 2,
                    Name = "Flying Fish",
                    Type = 1,
                    MaxAltitude = 500

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<HabitatAir>>();
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Provider).Returns(habitatAirs.Provider);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Expression).Returns(habitatAirs.Expression);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.ElementType).Returns(habitatAirs.ElementType);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.GetEnumerator()).Returns(habitatAirs.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            var actual = service.GetById(1);

            // Assert (expected,actual)
            Assert.AreEqual("Colugos", actual.Name);

        }

        [TestMethod]
        public void Insert_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<HabitatAir>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            service.Insert(new HabitatAir()
            {
                Id = 1,
                Name = "Colugos",
                Type = 1,
                MaxAltitude = 345

            });

            // Assert (expected,actual)
            mockSet.Verify(m => m.Add(It.IsAny<HabitatAir>()), Times.Once);

        }

        [TestMethod]
        public void Update_Test()
        {
            IQueryable<HabitatAir> habitatAirs = new List<HabitatAir>
            {
                new HabitatAir()
                {
                    Id = 1,
                    Name = "Colugos",
                    Type = 1,
                    MaxAltitude = 345

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<HabitatAir>>();
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Provider).Returns(habitatAirs.Provider);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Expression).Returns(habitatAirs.Expression);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.ElementType).Returns(habitatAirs.ElementType);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.GetEnumerator()).Returns(habitatAirs.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            var actual = service.Update(new HabitatAir()
            {
                Id = 1,
                Name = "Colugos 2",
                Type = 1,
                MaxAltitude = 599

            });

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Save_Test()
        {
            // Arrange
            var mockSet = new Mock<DbSet<HabitatAir>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            service.Save();


            // Assert (expected,actual)
            mockContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [TestMethod]
        public void Delete_Test()
        {
            IQueryable<HabitatAir> habitatAirs = new List<HabitatAir>
            {
                new HabitatAir()
                {
                    Id = 2,
                    Name = "Colugos",
                    Type = 1,
                    MaxAltitude = 345

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<HabitatAir>>();
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Provider).Returns(habitatAirs.Provider);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Expression).Returns(habitatAirs.Expression);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.ElementType).Returns(habitatAirs.ElementType);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.GetEnumerator()).Returns(habitatAirs.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            var actual = service.Delete(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Enable_Test()
        {
            IQueryable<HabitatAir> habitatAirs = new List<HabitatAir>
            {
                new HabitatAir()
                {
                    Id = 2,
                    Name = "Colugos",
                    Type = 1,
                    MaxAltitude = 345

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<HabitatAir>>();
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Provider).Returns(habitatAirs.Provider);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.Expression).Returns(habitatAirs.Expression);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.ElementType).Returns(habitatAirs.ElementType);
            mockSet.As<IQueryable<HabitatAir>>().Setup(m => m.GetEnumerator()).Returns(habitatAirs.GetEnumerator());


            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.HabitatAir).Returns(mockSet.Object);

            //Act
            var service = new HabitatAirService(mockContext.Object);
            var actual = service.Enable(2);

            // Assert (expected,actual)
            Assert.IsTrue(actual);

        }
    }
}
