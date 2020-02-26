using System.Collections.Generic;
using System.Threading.Tasks;
using Triangle.StudentEntitiesInterface;

namespace Triangle.StudentBusinessServicesInterface
{
    /// <summary>
    /// Interface Student Business Service
    /// </summary>
    public interface IStudentBusinessService
    {
        //Task<IStudentEntity> GetStudentById(int studentId);
        IStudentEntity GetStudentById(int studentId);
        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Entity List</returns>
        Task<IList<IStudentEntity>> GetAllStudentList();

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentEntity">Student Entity</param>
        /// <returns>Entity Id</returns>
        //int Createstudent(IStudentEntity studentEntity);
        Task<IStudentEntity> Createstudent(IStudentEntity studentEntity);

        /// <summary>
        /// Get AllStudentList With Paging Sorting
        /// </summary>
        /// <param name="searchValue">searchValue</param>
        /// <param name="pageNo">page No</param>
        /// <param name="pageSize">page Size</param>
        /// <param name="sortColumn">sort Column</param>
        /// <param name="sortOrder">sort Order</param>
        /// <returns>Student data table</returns>
        List<IStudentEntity> GetAllStudentListWithPaging_Sorting(string searchValue, int pageNo, int pageSize, string sortColumn, string sortOrder);
    }
}
