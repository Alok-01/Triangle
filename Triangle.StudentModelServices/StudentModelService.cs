using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Triangle.Common.CommonModel;
using Triangle.StudentBusinessServicesInterface;
using Triangle.StudentEntities;
using Triangle.StudentEntitiesInterface;
using Triangle.StudentModelServicesInterface;
using Triangle.StudentViewModels;

namespace Triangle.StudentModelServices
{
    /// <summary>
    /// Student Model Service
    /// </summary>
    public class StudentModelService : IStudentModelService
    {
        /// <summary>
        /// IStudentBusinessService
        /// </summary>
        readonly IStudentBusinessService _studentBusinessService;

        /// <summary>
        /// Constructor Student Model Service
        /// </summary>
        /// <param name="studentBusinessService">IStudentBusinessService</param>
        public StudentModelService(IStudentBusinessService studentBusinessService)
        {
            _studentBusinessService = studentBusinessService;
        }

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentRegistrationModel"></param>
        /// <returns>Student Registration</returns>
        public async Task<ResponseModel<StudentRegistrationModel>> CreateStudent(StudentRegistrationModel studentRegistrationModel)
        {
            ResponseModel<StudentRegistrationModel> returnResponse = new ResponseModel<StudentRegistrationModel>();
            try
            {
                IStudentEntity studentEntity = new StudentEntity()
                {
                    StudentId = studentRegistrationModel.StudentId,
                    StudentName = studentRegistrationModel.StudentName,
                    StudentFatherName = studentRegistrationModel.StudentFatherName,
                    StudentMotherName = studentRegistrationModel.StudentMotherName,
                    StudentRollNumber = studentRegistrationModel.StudentRollNumber
                };
                returnResponse.ReturnStatus = true;
                var result = await _studentBusinessService.Createstudent(studentEntity);
                studentRegistrationModel.StudentId = result.StudentId;
                returnResponse.Entity = studentRegistrationModel;

            }
            catch (Exception ex)
            {
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            return returnResponse;
        }

        public async Task<ResponseModel<StudentRegistrationModel>> GetStudentById(int studentId)
        {
            ResponseModel<StudentRegistrationModel> responseModel = new ResponseModel<StudentRegistrationModel>();

            var student = await _studentBusinessService.GetStudentById(studentId);

            var temp = new StudentRegistrationModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                StudentFatherName = student.StudentFatherName,
                StudentMotherName = student.StudentMotherName,
                StudentRollNumber = student.StudentRollNumber
            };

            responseModel.Entity = temp;
            responseModel.ListObject.Add(temp);
            responseModel.ReturnStatus = true;
            return responseModel;
        }

        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Registration Model</returns>
        public async Task<ResponseModel<StudentRegistrationModel>> GetAllStudentList()
        {
            ResponseModel<StudentRegistrationModel> returnResponse = new ResponseModel<StudentRegistrationModel>();
            var lstStudent = await _studentBusinessService.GetAllStudentList();
            if (lstStudent.Count <= 0)
            {
                returnResponse.ReturnMessage.Add("No Record Found");
                returnResponse.ReturnStatus = false;
                return returnResponse;
            }
            foreach (var item in lstStudent)
            {
                var temp = new StudentRegistrationModel
                {
                    StudentId = item.StudentId,
                    StudentName = item.StudentName,
                    StudentFatherName = item.StudentFatherName,
                    StudentMotherName = item.StudentMotherName,
                    StudentRollNumber = item.StudentRollNumber
                };

                returnResponse.ListObject.Add(temp);
            }

            return returnResponse;
        }

        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Registration Model</returns>
        public async Task<List<StudentRegistrationModel>> GetAllStudentListCqrs()
        {
            List<StudentRegistrationModel> returnResponse = new List<StudentRegistrationModel>();
            var lstStudent = await _studentBusinessService.GetAllStudentList();

            foreach (var item in lstStudent)
            {
                var temp = new StudentRegistrationModel
                {
                    StudentId = item.StudentId,
                    StudentName = item.StudentName,
                    StudentFatherName = item.StudentFatherName,
                    StudentMotherName = item.StudentMotherName,
                    StudentRollNumber = item.StudentRollNumber
                };

                returnResponse.Add(temp);
            }

            return returnResponse;
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
        public List<StudentRegistrationModel> GetAllStudentListWithPaging_Sorting(string searchValue, int pageNo, int pageSize, string sortColumn, string sortOrder)
        {
            List<StudentRegistrationModel> returnResponse = new List<StudentRegistrationModel>();
            var lstStudent = _studentBusinessService.GetAllStudentListWithPaging_Sorting(searchValue, pageNo, pageSize, sortColumn, sortOrder);

            foreach (var item in lstStudent)
            {
                var temp = new StudentRegistrationModel
                {
                    StudentId = item.StudentId,
                    StudentName = item.StudentName,
                    StudentFatherName = item.StudentFatherName,
                    StudentMotherName = item.StudentMotherName,
                    StudentRollNumber = item.StudentRollNumber
                };
                returnResponse.Add(temp);
            }

            return returnResponse;
        }

       
    }
}
