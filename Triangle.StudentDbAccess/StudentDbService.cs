using System;
using System.Data;
using System.Threading.Tasks;
using Triangle.DbManagement;
using Triangle.StudentEntitiesInterface;

namespace Triangle.StudentDbAccess
{
    /// <summary>
    /// Student Db Service
    /// </summary>
    public static class StudentDbService
    {
        /// <summary>
        /// Insert or Update Student
        /// </summary>
        /// <param name="studentEntity">The Student Entity</param>
        /// <returns> entity id</returns>
        //public static int InsertUpdate(IStudentEntity studentEntity)
        public static IStudentEntity InsertUpdate(IStudentEntity studentEntity)
        {
            try
            {
                using var comm = GenericDataAccess.CreateCommand(Connections.Configuration.StudentV4Db);
                comm.CommandText = "Student_InsertUpdate";
                comm.AddParamWithValue("@StudentId", DbType.Int32, studentEntity.StudentId);
                comm.AddParamWithValue("@StudentName", DbType.String, studentEntity.StudentName);
                comm.AddParamWithValue("@StudentRollNumber", DbType.String, studentEntity.StudentRollNumber);
                comm.AddParamWithValue("@StudentFatherName", DbType.String, studentEntity.StudentFatherName);
                comm.AddParamWithValue("@StudentMotherName", DbType.String, studentEntity.StudentMotherName);
                var resu = GenericDataAccess.ExecuteNonQuery(comm);
                studentEntity.StudentId = resu;
            }
            catch (Exception ex)
            {
                DataErrorLogger.LogError(ex);
                throw ex;
            }

            return studentEntity;
        }

        /// <summary>
        /// Fetch All Students
        /// </summary>
        /// <returns>Data Table</returns>
        public static TransferableDataTable FetchAllStudents()
        {
            try
            {
                using (var comm = GenericDataAccess.CreateCommand(Connections.Configuration.StudentV4Db))
                {
                    comm.CommandText = "dbo.Student__FetchAll";
                    var result = GenericDataAccess.ExecuteSelectCommand(comm);
                    return result;
                }
            }
            catch (Exception ex)
            {
                DataErrorLogger.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Fetch Student By StudentId
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>Return student data table</returns>
        public static TransferableDataTable FetchStudentByStudentId(int studentId)
        {
            try
            {
                using (var comm = GenericDataAccess.CreateCommand(Connections.Configuration.StudentV4Db))
                {
                    comm.CommandText = "dbo.Student__FetchByStudentId";
                    comm.AddParamWithValue("@StudentId", DbType.Int32, studentId);
                    var result = GenericDataAccess.ExecuteSelectCommand(comm);
                    return result;
                }
            }
            catch (Exception ex)
            {
                DataErrorLogger.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// FetchAllStudents With Paging Sorting
        /// </summary>
        /// <param name="searchValue">searchValue</param>
        /// <param name="pageNo">page No</param>
        /// <param name="pageSize">page Size</param>
        /// <param name="sortColumn">sort Column</param>
        /// <param name="sortOrder">sort Order</param>
        /// <returns>Student data table</returns>
        public static TransferableDataTable FetchAllStudentsWithPaging_Sorting(string searchValue, int pageNo, int pageSize, string sortColumn,string sortOrder)
        {
            try
            {
                using (var comm = GenericDataAccess.CreateCommand(Connections.Configuration.StudentV4Db))
                {
                    comm.CommandText = "dbo.Student__FetchAll_Paging";
                    comm.AddParamWithValue("@SearchValue", DbType.String, searchValue);
                    comm.AddParamWithValue("@PageNo", DbType.Int32, pageNo);
                    comm.AddParamWithValue("@PageSize", DbType.Int32, pageSize);
                    comm.AddParamWithValue("@SortColumn", DbType.String, sortColumn);
                    comm.AddParamWithValue("@SortOrder", DbType.String, sortOrder);
                    var result = GenericDataAccess.ExecuteSelectCommand(comm);
                    return result;
                }
            }
            catch (Exception ex)
            {
                DataErrorLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
