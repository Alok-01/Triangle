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
        public async Task<List<IStudentEntity>> GetAllStudentList()
        {
            List<IStudentEntity> studentEntities = new List<IStudentEntity>();
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
            var result = StudentDbService.InsertUpdate(studentEntity);
            return result;
        }

        //public IStudentEntity GetStudentById(int studentId)
        public async Task<IStudentEntity> GetStudentById(int studentId)
        {
            if (studentId <= 0) return null;

            using (var dataTransfer = StudentDbService.FetchStudentByStudentId(studentId))
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

                        return temp;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Get AllStudentList With Paging Sorting
        /// </summary>
        /// <param name="searchValue">searchValue</param>
        /// <param name="pageNo">page No</param>
        /// <param name="pageSize">page Size</param>
        /// <param name="sortColumn">sort Column</param>
        /// <param name="sortOrder">sort Order</param>
        /// <returns>Student data table</returns>
        public List<IStudentEntity> GetAllStudentListWithPaging_Sorting(string searchValue, int pageNo, int pageSize, string sortColumn, string sortOrder)
        {
            List<IStudentEntity> studentEntities = new List<IStudentEntity>();
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
    }
}
