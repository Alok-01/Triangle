using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triangle.StudentViewModels;

namespace Triangle.ApiStudent.Queries
{
    public class GetAllStudentQuery : IRequest<List<StudentRegistrationModel>>
    {
    }
}
