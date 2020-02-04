using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Triangle.StudentEntities;
using Triangle.StudentEntitiesInterface;
using Triangle.StudentRepositoriesInterface;

namespace Triangle.UnitTestStudent
{
    [TestClass]
    public class StudentListTest
    {
        public static Mock<IStudenteRepository> mockEmployeeRepository;
        public StudentListTest()
        {
            mockEmployeeRepository = new Mock<IStudenteRepository>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var mockstudent = new List<IStudentEntity>();

            mockstudent.Add(new StudentEntity { StudentId = 1, StudentRollNumber = "B10", StudentName = "John", StudentFatherName = "Paul", StudentMotherName = "Lena" });
            mockstudent.Add(new StudentEntity { StudentId = 1, StudentRollNumber = "C10", StudentName = "Jack", StudentFatherName = "Pundit", StudentMotherName = "Kaul" });

            //Mock<IStudentEntity> cardMock = new Mock<IStudentEntity>();
            //cardMock.Setup(s => s.StudentId).Returns(1);
            var  abc = mockEmployeeRepository.Setup(s => s.GetAllStudentList()).Returns(mockstudent);
            Assert.AreEqual(2, mockstudent.Count);
            //mockEmployeeRepository.Verify(s => s.GetAllStudentList());
    }

    }
}
