using System.Collections.Generic;
using System.Threading.Tasks;
using Triangle.Common.CommonModel;
using Triangle.StudentViewModels;

namespace Triangle.StudentModelServicesInterface
{
    /// <summary>
    /// Interface Student Model Service
    /// </summary>
    public interface IStudentModelService
    {
        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="vm">StudentRegistrationModel Model</param>
        /// <returns></returns>
        List<StudentRegistrationModel> GetAllStudentList();

        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Registration Model</returns>
        //int CreateStudent(StudentRegistrationModel vm);
        Task<ResponseModel<StudentRegistrationModel>> CreateStudent(StudentRegistrationModel studentRegistrationModel);
    }
}
