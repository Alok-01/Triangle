namespace Triangle.StudentEntitiesInterface
{
    public interface IStudentEntity
    {
        int StudentId { get; set; }

        string StudentName { get; set; }

        string StudentRollNumber { get; set; }

        string StudentFatherName { get; set; }

        string StudentMotherName { get; set; }
    }
}
