using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Triangle.ApiStudent.Queries;
using Triangle.StudentModelServicesInterface;
using Triangle.StudentViewModels;

namespace Triangle.ApiStudent.Handlers
{
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentQuery, List<StudentRegistrationModel>>
    {
        private readonly IStudentModelService _studentModelService;

        public GetAllStudentHandler(IStudentModelService studentModelService)
        {
            _studentModelService = studentModelService;
        }

        public async Task<List<StudentRegistrationModel>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentModelService.GetAllStudentListCqrs();

            return response;
        }
    }
}
