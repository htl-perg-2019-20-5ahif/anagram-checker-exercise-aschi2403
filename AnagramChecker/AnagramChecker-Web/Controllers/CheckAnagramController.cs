using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramChecker_Library;
using Microsoft.Extensions.Configuration;

namespace AnagramChecker_Web.Controllers
{
    [ApiController]
    [Route("api/checkAnagram")]
    public class CheckAnagramController : ControllerBase
    {
        private readonly ILogger<CheckAnagramController> _logger;
        private readonly AnagramChecker anagramChecker;
        private readonly IConfiguration config;
        private readonly string path;

        public CheckAnagramController(ILogger<CheckAnagramController> logger)
        {
            _logger = logger;
            config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            path = config["filepath"];
            anagramChecker = new AnagramChecker(path);
        }

        [HttpPost]
        public IActionResult checkAnagram([FromBody] string w1, string w2)
        {
            if (anagramChecker.CheckIfAnagrams(w1, w2))
                return Ok();
            else
                return BadRequest();
        }
    }
}
