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
    }
}
