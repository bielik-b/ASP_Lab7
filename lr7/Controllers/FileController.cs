using lr7.Models;
using Microsoft.AspNetCore.Mvc;

namespace lr7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(FileModel file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                TextWriter writer = new StreamWriter(memoryStream);
                writer.WriteLine($"{file.UserName} {file.UserSurname}");
                writer.Flush();
                return File(memoryStream.GetBuffer(), "text/plain", $"{file.FileName}.txt");
            }
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
