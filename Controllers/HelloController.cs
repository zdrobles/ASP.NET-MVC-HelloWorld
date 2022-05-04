using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" +
                          "<input type='text' name='name' />" +
                          "<select name = 'language'>" +
                            "<option value = 'french' selected> French </option >" +
                            "<option value = 'english' selected> English </option>" +
                            "<option value = 'hindi' selected> Hindi </option >" +
                            "<option value = 'mandarin' selected> Mandarin </option>" +
                            "<option value = 'spanish' selected> Spanish </option>" +
                          "</select >" +
                          "<input type='submit' value='Greet Me' />" +
                          "</form>";

            return Content(html, "text/html");
        }

        [HttpGet("welcome/{name?}")]
        [HttpPost]        
        public IActionResult Welcome(string language, string name = "World")
        {
            return Content($"<h1>{CreateMessage(name, language)}</h1>", "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            string greeting = "";            

            switch (language)
            {
                case "french":
                    greeting = "Bonjour";
                    break;
                case "english":
                    greeting = "Hello";
                    break;
                case "hindi":
                    greeting = "Namaste";
                    break;
                case "mandarin":
                    greeting = "Ni hao";
                    break;
                case "spanish":
                    greeting = "Hola";
                    break;
            }

            return $"{greeting} <span style='color: blue'>{name}</span>";
        }
    }
}
