using System.Collections.Generic;
using System.Threading.Tasks;
using Triangle.StudentEntitiesInterface;

namespace Triangle.StudentRepositoriesInterface
{
    /// <summary>
    /// Interface Student Repository
    /// </summary>
    public interface IStudenteRepository
    {
        //Task<IStudentEntity> GetStudentById(int studentId);
        IStudentEntity GetStudentById(int studentId);

        /// <summary>
        /// Get All students 
        /// </summary>
        /// <returns>Student List</returns>
        //Task<IList<IStudentEntity>> GetAllStudentList();
        List<IStudentEntity> GetAllStudentList();

        /// <summary>
        /// Student Entity
        /// </summary>
        /// <param name="studentEntity">Stduent Entity</param>
        /// <returns></returns>
        Task<IStudentEntity> CreateStudent(IStudentEntity studentEntity);

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
