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
        /// Get All Student
        /// </summary>
        /// <param name="vm">StudentRegistrationModel Model</param>
        /// <returns></returns>
        Task<ResponseModel<StudentRegistrationModel>> GetAllStudentList();

        Task<List<StudentRegistrationModel>> GetAllStudentListCqrs();

        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Registration Model</returns>
        //int CreateStudent(StudentRegistrationModel vm);
        Task<ResponseModel<StudentRegistrationModel>> CreateStudent(StudentRegistrationModel studentRegistrationModel);

        /// <summary>
        /// Get AllStudentList With Paging Sorting
        /// </summary>
        /// <param name="searchValue">searchValue</param>
        /// <param name="pageNo">page No</param>
        /// <param name="pageSize">page Size</param>
        /// <param name="sortColumn">sort Column</param>
        /// <param name="sortOrder">sort Order</param>
        /// <returns>Student data table</returns>
        List<StudentRegistrationModel> GetAllStudentListWithPaging_Sorting(string searchValue, int pageNo, int pageSize, string sortColumn, string sortOrder);
    }
}
