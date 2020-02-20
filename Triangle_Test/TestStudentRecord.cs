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
            List<IStudentEntity> mockstudent = new List<IStudentEntity>
            {
                
                new StudentEntity { StudentId = 1, StudentRollNumber = "B10", StudentName = "John", StudentFatherName = "Paul", StudentMotherName = "Lena" },
                new StudentEntity { StudentId = 2, StudentRollNumber = "C10", StudentName = "Jack", StudentFatherName = "Pundit", StudentMotherName = "Kaul" }
            };
            
            //act
            var abc = mockEmployeeRepository.Setup(s => s.GetAllStudentList()).Returns(mockstudent);
            // assert
            Assert.AreEqual(2, mockstudent.Count);
            
        }
    }
}
