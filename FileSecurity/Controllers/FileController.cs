using FileSignatures;
using FileSignatures.Formats;
using Microsoft.AspNetCore.Mvc;

namespace FileSecurity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly string fileDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        private readonly IFileFormatInspector _inspector;

        public FileController(IFileFormatInspector inspector)
        {
            _inspector = inspector;
            if (!Directory.Exists(fileDirectoryPath))
            {
                Directory.CreateDirectory(fileDirectoryPath);
            }
        }

        [HttpPost]
        [Route("Upload")]
        public ActionResult<string> UploadFile(IFormFile file)
        {
            // allow only jpg file
            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".jpg")
            {
                return BadRequest("Only jpg file is allowed");
            }

            // check file signature
            var fileSignature = _inspector.DetermineFileFormat(file.OpenReadStream());
            if (fileSignature is not Jpeg)
            {
                return BadRequest("The file does not have a valid jpeg signature");
            }

            // save file to disk
            var filePath = Path.Combine(fileDirectoryPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Ok(file.FileName);
        }

        [HttpGet]
        [Route("Download")]
        public ActionResult DownloadFile([FromQuery] string fileId)
        {
            var filePath = Path.Combine(fileDirectoryPath, fileId);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            var file = System.IO.File.ReadAllBytes(filePath);

            return File(file, "application/octet-stream", fileId);
        }
    }
}
