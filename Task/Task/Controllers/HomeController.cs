using Microsoft.AspNetCore.Mvc;
using Task.Infrastructure.Interfaces;

namespace Task.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IWordCounter _wordCounter;

        public HomeController(IWordCounter wordCounter)
        {
            _wordCounter = wordCounter;
        }

        [Route("")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet, Route("result/{text}")]        
        public IActionResult Result([FromRoute]string text)
        {
            return Ok(_wordCounter.CountWords(text));
        }
    }
}
