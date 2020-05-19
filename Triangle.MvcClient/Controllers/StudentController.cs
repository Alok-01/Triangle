using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Triangle.Logging;
using Triangle.MvcClient.Common;
using Triangle.StudentViewModels;

namespace Triangle.MvcClient.Controllers
{
    public class StudentController : ClientUtilityController//Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        //Note Ideally url come from appsetting.json or database
        private static string apiGetStudentUri = "https://localhost:44345/student/getstudent?id="; // Triangle.ApiStudent = ApiOne
        //private static string apiPostStudentUri = "https://localhost:44345/student/secretcreatestudent"; // Triangle.ApiStudent = ApiOne
        private static string apiPostStudentUri = "/student/secretcreatestudent"; // Triangle.ApiStudent = ApiOne
        private static string apiGetStudentListUri = "https://localhost:44345/student/getallstudent"; // Triangle.ApiStudent = ApiOne

        /// <summary>
        /// Student Controller
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public StudentController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Student Registration Form Index
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Name = string.Empty;
            return View();
        }

        /// <summary>
        /// Index Post to Save Student Registration Form
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(StudentRegistrationModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                var result = await this.ApiPostAsync(apiPostStudentUri, vm, "StudentApiClient");
                if (!result.IsSuccessStatusCode)
                {
                    ViewBag.Name = "Unable to Save At the Moment";
                    return View(vm);
                }
                else
                {
                   
                    ViewBag.Status = $"The student name { vm.StudentName } is record created! ";
                    RedirectToAction("studentlist", "student");
                    // return View(vm);
                }
            }
            catch (Exception ex)
            {
                LogSecurity.Warning("Exception on StudentRegistration Post : ", ex.InnerException.ToString());
                //return View(vm);
            }

            return View(vm);
            //RedirectToAction("studentlist", "student");
            
        }

        /// <summary>
        /// Student Id todo: complete model code need to implement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("/student/student")]
        public async Task<IActionResult> Student(int id)
        {
            var strUrl = apiGetStudentUri + id;

            var result = await this.ApiGetAsync(strUrl);
            //var model = JsonConvert.DeserializeObject<List<StudentRegistrationModel>>(await result.Content.ReadAsStringAsync());
            var model = await result.Content.ReadAsStringAsync();
            var modeljson = JsonConvert.DeserializeObject<StudentRegistrationModel>(model);
            return View("Student", modeljson);
            //return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Student Id todo: complete model code need to implement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("/student/studentlist")]
        public async Task<IActionResult> StudentList()
        {
            var strUrl = apiGetStudentListUri;

            var result = await this.ApiGetAsync(strUrl);
            //var model = JsonConvert.DeserializeObject<List<StudentRegistrationModel>>(await result.Content.ReadAsStringAsync());
            var model = await result.Content.ReadAsStringAsync();
            var modeljson = JsonConvert.DeserializeObject<List<StudentRegistrationModel>>(model);
            return View("StudentList", modeljson);
            //return RedirectToAction("Index", "Home");
        }
    }
}
