using Xunit;
using Triangle.StudentBusinessServicesInterface;
using Triangle.StudentEntitiesInterface;
using Triangle.StudentEntities;
using Triangle.StudentBusinessServices;
using Triangle.StudentRepositoriesInterface;
using Moq;
using System.Collections.Generic;
using System.Linq;
namespace Student_Test
{
    public class TestStudentQuery
    {
        [Fact]
        public void Test_TotalStudentCountBeTwo()
        {
            var studentEntity = new StudentEntity();
            var mockStudenteRepository = new Mock<IStudenteRepository>();
            var mockBusinessService = new Mock<IStudentBusinessService>();
            var mockstudent = new List<IStudentEntity>
            {

                new StudentEntity { StudentId = 1, StudentRollNumber = "B10", StudentName = "John", StudentFatherName = "Paul", StudentMotherName = "Lena" },
                new StudentEntity { StudentId = 2, StudentRollNumber = "C10", StudentName = "Jack", StudentFatherName = "Pundit", StudentMotherName = "Kaul" }
            };

            var res = mockBusinessService.Setup(d => d.GetAllStudentList()).Returns(mockstudent);

            //var abc = mockBusinessService.Object;

            //Assert.Equal("2", abc.GetAllStudentList().Count.ToString());
            //Assert.Equal("2", abc.GetAllStudentList().Count.ToString());
            Assert.Equal("2", mockBusinessService.Object.GetAllStudentList().Count.ToString());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        public void Test_FinStudentbyId(int id)
        {
            var mockStudenteRepository = new Mock<IStudenteRepository>();
            var mockBusinessService = new Mock<IStudentBusinessService>();
            var mockstudent = new List<StudentEntity>
            {

                new StudentEntity { StudentId = 1, StudentRollNumber = "B10", StudentName = "John", StudentFatherName = "Paul", StudentMotherName = "Lena" },
                new StudentEntity { StudentId = 2, StudentRollNumber = "C10", StudentName = "Jack", StudentFatherName = "Pundit", StudentMotherName = "Kaul" }
            };

            IStudentEntity studentEntity = mockstudent.Where(s => s.StudentId == id).SingleOrDefault();
            mockBusinessService.Setup(d => d.GetStudentById(id)).Returns(studentEntity);
            Assert.Equal(id.ToString(), mockBusinessService.Object.GetStudentById(id).StudentId.ToString());
        }


        [Theory]
        [InlineData(1, "John")]
        [InlineData(2, "Jack")]
        [InlineData(3, "Paul")]
        public void Test_FindStudentbyIdAndCheckByName(int id, string name)
        {
            var mockStudenteRepository = new Mock<IStudenteRepository>();
            var mockBusinessService = new Mock<IStudentBusinessService>();
            var mockstudent = new List<StudentEntity>
            {

                new StudentEntity { StudentId = 1, StudentRollNumber = "B10", StudentName = "John", StudentFatherName = "Paul", StudentMotherName = "Lena" },
                new StudentEntity { StudentId = 2, StudentRollNumber = "C10", StudentName = "Jack", StudentFatherName = "Pundit", StudentMotherName = "Kaul" },
                new StudentEntity { StudentId = 3, StudentRollNumber = "X10", StudentName = "Om", StudentFatherName = "Karma", StudentMotherName = "Sadhana" }
            };

            IStudentEntity studentEntity = mockstudent.Where(s => s.StudentId == id).SingleOrDefault();
            mockBusinessService.Setup(d => d.GetStudentById(id)).Returns(studentEntity);
            
            if (id == 3) 
            {
                Assert.NotEqual(name, mockBusinessService.Object.GetStudentById(id).StudentName);
            }
            else
            {
                Assert.Equal(name, mockBusinessService.Object.GetStudentById(id).StudentName);
            }
        }
    }
}
