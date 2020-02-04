using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Triangle.StudentEntities;
using Triangle.StudentEntitiesInterface;
using Triangle.StudentRepositoriesInterface;

namespace Triangle_Test
{
    [TestClass]
    public class TestStudentRecord
    {
        [TestMethod]
        public void TestGetStudentListCount()
        {
            // arrange
            Mock<IStudenteRepository> mockEmployeeRepository = new Mock<IStudenteRepository>();
            var mockstudent = new List<IStudentEntity>();
            //act
            mockstudent.Add(new StudentEntity { StudentId = 1, StudentRollNumber = "B10", StudentName = "John", StudentFatherName = "Paul", StudentMotherName = "Lena" });
            mockstudent.Add(new StudentEntity { StudentId = 1, StudentRollNumber = "C10", StudentName = "Jack", StudentFatherName = "Pundit", StudentMotherName = "Kaul" });
            // assert
            var abc = mockEmployeeRepository.Setup(s => s.GetAllStudentList()).Returns(mockstudent);
            Assert.AreEqual(2, mockstudent.Count);
            
        }
    }
}
