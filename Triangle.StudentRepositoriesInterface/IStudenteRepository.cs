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


    }
}
