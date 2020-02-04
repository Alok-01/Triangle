using Triangle.StudentEntitiesInterface;

namespace Triangle.StudentEntities
{

    /// <summary>
    /// Student Entity Class
    /// </summary>
    public class StudentEntity : IStudentEntity
    {
        /// <summary>
        /// Student Id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Student Name
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Student Roll Number
        /// </summary>
        public string StudentRollNumber { get; set; }

        /// <summary>
        /// Student Father Name
        /// </summary>
        public string StudentFatherName { get; set; }

        /// <summary>
        /// Student Father Name
        /// </summary>
        public string StudentMotherName { get; set; }
    }
}
