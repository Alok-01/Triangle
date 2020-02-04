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
        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Entity List</returns>
        IList<IStudentEntity> GetAllStudentList();

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentEntity">Student Entity</param>
        /// <returns>Entity Id</returns>
        //int Createstudent(IStudentEntity studentEntity);
        Task<IStudentEntity> Createstudent(IStudentEntity studentEntity);
    }
}
