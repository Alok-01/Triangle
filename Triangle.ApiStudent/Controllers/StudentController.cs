using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Triangle.StudentModelServicesInterface;
using Triangle.StudentViewModels;
using Triangle.Common.CommonModel;
using System.Threading.Tasks;

namespace Triangle.ApiStudent
{
    /// <summary>
    /// Student API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// Student Model Service
        /// </summary>
        IStudentModelService _studentModelService;

        /// <summary>
        /// StudentController
        /// </summary>
        /// <param name="studentModelService">studentModelService </param>
        public StudentController(IStudentModelService studentModelService)
        {
            _studentModelService = studentModelService;
        }

        /// <summary>
        /// CreateStudent
        /// </summary>
        /// <param name="vm">StudentRegistrationModel</param>
        /// <returns>View Model</returns>
        [Authorize]
        [Route("/student/secretcreatestudent")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentRegistrationModel vm)
        {
            ResponseModel<StudentRegistrationModel> response;
            if (ModelState.IsValid)
            {
                response = await _studentModelService.CreateStudent(vm);
                if (response.ReturnStatus == true)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            return BadRequest(vm);
        }

        /// <summary>
        /// Get Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Route("/student/getstudent")]
        [HttpGet]
        public IActionResult GetStudent(int id)
        {
            var result = _studentModelService.GetAllStudentList().Where(s => s.StudentId == id);
            return Ok(result);
        }

        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("/student/getallstudent")]
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var result = _studentModelService.GetAllStudentList();
            return Ok(result);
        }
    }
}