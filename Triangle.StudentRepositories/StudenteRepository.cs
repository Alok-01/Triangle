using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using Triangle.StudentDbAccess;
using Triangle.StudentEntities;
using Triangle.StudentEntitiesInterface;
using Triangle.StudentRepositoriesInterface;

namespace Triangle.StudentRepositories
{
    /// <summary>
    /// Student Repository
    /// </summary>
    public class StudenteRepository : IStudenteRepository
    {
        /// <summary>
        /// Get All students 
        /// </summary>
        /// <returns>Student List</returns>
        //public async Task<IList<IStudentEntity>> GetAllStudentList()
        public List<IStudentEntity> GetAllStudentList()
        {
            List<IStudentEntity> studentEntities  = new List<IStudentEntity>();
            using (var dataTransfer = StudentDbService.FetchAllStudents())
            {
                if (dataTransfer.Table.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTransfer.Table.Rows)
                    {
                        var temp = new StudentEntity
                        {
                            StudentId = int.Parse(row["StudentId"].ToString(), CultureInfo.InvariantCulture),
                            StudentName = row["StudentName"].ToString(),
                            StudentRollNumber = row["StudentRollNumber"].ToString(),
                            StudentFatherName = row["StudentFatherName"].ToString(),
                            StudentMotherName = row["StudentMotherName"].ToString()
                        };

                        studentEntities.Add(temp);
                    }
                }
            }
            return studentEntities;
        }

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentEntity">Student Entity</param>
        /// <returns>Entity Id</returns>
        //public int CreateStudent(IStudentEntity studentEntity)
        public async Task<IStudentEntity> CreateStudent(IStudentEntity studentEntity)
        {
            var result =  StudentDbService.InsertUpdate(studentEntity);
            return result;
        }
    }
}
