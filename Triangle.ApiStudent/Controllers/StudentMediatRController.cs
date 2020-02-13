using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triangle.ApiStudent.Queries;

namespace Triangle.ApiStudent
{
    public class StudentMediatRController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/studentm/getallstudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var query = new GetAllStudentQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
