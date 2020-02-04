using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiOne.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiOne.Controllers
{
    public class SecretController : Controller
    {
        [Authorize]
        [Route("/secret")]
        public string Index()
        {
            var userCliams = User.Claims.ToList();
            return "Secret Message by ApiOne";
        }

        [Route("/secret/Test")]
        public string Test()
        {
            return "Test";
        }

        //[Authorize]
        //[Route("/secretcreatestudent")]
        //[HttpPost]
        //public IActionResult CreateStudent(StudentRegistrationModel vm)
        //{
        //    var userCliams = User.Claims.ToList();
        //    var dto = vm;

        //    return Ok();

        //}
    }
}