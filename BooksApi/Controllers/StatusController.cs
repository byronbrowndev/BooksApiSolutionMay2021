using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    public class StatusController : ControllerBase
    {
        // GET /status
        [HttpGet("status")]
        public ActionResult GetTheStatus()
        {
            var response = new GetStatusResponse
            {
                Message = "looks good",
                LastChecked = DateTime.Now,
                CheckedBy = "joe@mama.com"
            };
            return Ok(response);
        }

        // GET /employees/3290392 (route param)
        [HttpGet("employees/{employeeId:int}")]
        public ActionResult GetEmployees(int employeeId)
        {
            return Ok($"Getting you information about employee {employeeId}");
        }

        // GET /blogs/{year:int}/{month:int}/{day:int}
        [HttpGet("/blogs/{year:int}/{month:int}/{day:int}")]
        public ActionResult GetBlogPosts(int year, int month, int day)
        {
            return Ok($"Blogs for {year}/{month}/{day}");
        }

        [HttpGet("employees")]
        public ActionResult GetAllEmployees([FromQuery] int maxCount, [FromQuery] string role = "All")
        {
            if(maxCount < 0)
            {
                return BadRequest("Maxcount has to be > 0");
            }

            return Ok($"sending you {role} employees Count {maxCount}");
        }
    }

    public class GetStatusResponse
    {
        public string Message { get; set; }
        public DateTime LastChecked { get; set; }
        public string CheckedBy { get; set; }
    }
}
