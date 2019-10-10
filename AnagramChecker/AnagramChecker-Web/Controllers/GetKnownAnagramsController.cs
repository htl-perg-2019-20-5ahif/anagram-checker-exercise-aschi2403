using AnagramChecker_Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramChecker_Web.Controllers
{
    [ApiController]
    [Route("api/getKnowAnagrams")]
    public class GetKnownAnagramsController : ControllerBase
    {
        private readonly ILogger<CheckAnagramController> _logger;
        private readonly AnagramChecker anagramChecker;
        private readonly IConfiguration config;
        private readonly string path;

        public GetKnownAnagramsController(ILogger<CheckAnagramController> logger)
        {
            config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            path = config["filepath"];
            _logger = logger;
            anagramChecker = new AnagramChecker(path);
        }

        [HttpGet]
        public IEnumerable<string> GetKnownAnagrams([FromHeader] string w)
        {
            var anagrams = anagramChecker.GetAnagrams(w);
            if(anagrams.ToList().Count == 0)
            {
                _logger.LogInformation("No anagram found for {0}", w);
                return null;
            }
            return anagrams;
        }
    }
}