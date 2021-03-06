﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Triangle.StudentBusinessServicesInterface;
using Triangle.StudentEntitiesInterface;
using Triangle.StudentRepositoriesInterface;

namespace Triangle.StudentBusinessServices
{
    /// <summary>
    /// Student Business Service
    /// </summary>
    public class StudentBusinessService : IStudentBusinessService
    {
        private readonly IStudenteRepository _studenteRepository;

        /// <summary>
        /// Constructor StudentBusinessService
        /// </summary>
        /// <param name="studenteRepository">IStudenteRepository</param>
        public StudentBusinessService(IStudenteRepository studenteRepository)
        {
            _studenteRepository = studenteRepository;
        }

        /// <summary>
        /// Get All Student List
        /// </summary>
        /// <returns>Student Entity List</returns>
        public async Task<IList<IStudentEntity>> GetAllStudentList()
        {
            var lstStudent = await _studenteRepository.GetAllStudentList();
            return lstStudent;
        }

        /// <summary>
        /// Get Student by id
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>Return Student id</returns>
        //public async Task<IStudentEntity> GetStudentById(int studentId)
        public async Task<IStudentEntity> GetStudentById(int studentId)
        {
            var studentEntity = await _studenteRepository.GetStudentById(studentId);
            return studentEntity;
        }

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentEntity">Student Entity</param>
        /// <returns>Entity Id</returns>
        //public int Createstudent(IStudentEntity studentEntity)
        public async Task<IStudentEntity> Createstudent(IStudentEntity studentEntity)
        {
            var result = await _studenteRepository.CreateStudent(studentEntity);
            return result;
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
            var lstStudent = _studenteRepository.GetAllStudentListWithPaging_Sorting(searchValue, pageNo, pageSize, sortColumn, sortOrder);
            return lstStudent;
        }
    }
}
