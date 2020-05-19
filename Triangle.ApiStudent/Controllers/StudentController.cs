using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Triangle.StudentModelServicesInterface;
using Triangle.StudentViewModels;
using Triangle.Common.CommonModel;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using Triangle.Logging;

namespace Triangle.ApiStudent
{
    /// <summary>
    /// Student API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        /// <summary>
        /// Student Model Service
        /// </summary>
        IStudentModelService _studentModelService;
        
        /// <summary>
        /// StudentController
        /// </summary>
        /// <param name="studentModelService">studentModelService </param>
        public StudentController(IStudentModelService studentModelService, ILogger<StudentController> logger)
        {
            _studentModelService = studentModelService;
            _logger = logger;
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
            Log.Information("Authenticated user making student/secretcreatestudent API call.");
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
                    LogSecurity.Warning("Unauthorized access attempted Create {student}",  vm.StudentName);
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
        public async Task<IActionResult> GetStudent(int id)
        {
            var re = await _studentModelService.GetAllStudentList();
            if (!re.ReturnStatus)
            {
                return NoContent();
            }
            var resulta = _studentModelService.GetAllStudentList().Result.ListObject.Where(s => s.StudentId == id).FirstOrDefault();
            //var studentResult = await _studentModelService.GetStudentById(id);
            var studentResult = re.ListObject.Where(s => s.StudentId == id).FirstOrDefault();
            return Ok(studentResult);
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
            var result = _studentModelService.GetAllStudentList().Result.ListObject;
            return Ok(result);
        }
    }
}