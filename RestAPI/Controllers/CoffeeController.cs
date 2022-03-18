using Contracts.Models.RequestModels;
using Contracts.Models.ResponseModels;
using Domain.Services;
using Ionic.Zip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("coffee")]
    public class CoffeeController : ControllerBase
    {
        private readonly ILogger<CoffeeController> _logger;

        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService, ILogger<CoffeeController> logger)
        {
            _coffeeService = coffeeService;
            _logger = logger;
        }

        /// <summary>
        /// Get all coffee cards
        /// </summary>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Not found</response>
        /// <remarks>Returns coffee list</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(CoffeeResponseModel), 200)]
        public async Task<ActionResult<IEnumerable<CoffeeResponseModel>>> GetAll()
        {
            var coffeeItems = await _coffeeService.GetAllAsync();

            _logger.LogWarning("There are {number} coffee items", coffeeItems.ToList().Capacity);

            return Ok(coffeeItems);
        }

        /// <summary>
        /// Download coffee picture by name
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>It is necessary to specify a name with extension</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("download/{name}")]
        public async Task<ActionResult> DownloadCoffeePicture(string name)
        {
            var fileName = name;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(bytes, contentType, Path.GetFileName(filePath));
        }

        /// <summary>
        /// Download coffee zip picture by name
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>It is necessary to specify a name with extension</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("downloadZip/{name}")]
        public ActionResult DownloadZipCoffeePicture(string name)
        {
            var fileName = name;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var ms = new MemoryStream();

            using var zip = new ZipFile();

            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.AddFile(filePath, "");
            zip.Save(ms);

            ms.Position = 0;

            var fileDownloadName = $"{Path.GetFileNameWithoutExtension(filePath)}.zip";

            //var ms = new MemoryStream();

            //var sw = new StreamWriter(ms);
            //sw.Write("<item><name>wrench</name></item>");
            //sw.Flush();
            //ms.Position = 0;

            //var fileDownloadName = $"{Path.GetFileNameWithoutExtension(filePath)}.txt";

            return File(ms, "application/zip", fileDownloadName);
        }

        /// <summary>
        /// Add coffee card
        /// </summary>
        /// <param name="requestModel"></param>
        /// <response code="200">Successful operation</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CoffeeResponseModel>> Add([FromForm] CoffeeRequestModel requestModel)
        {
            var cultureInfo = CultureInfo.CurrentCulture;
            var cultureInfo1 = CultureInfo.CurrentCulture;

            var coffee = await _coffeeService.AddAsync(requestModel);

            return Ok(coffee);
        }

        /// <summary>
        /// Delete coffee card by id
        /// </summary>
        /// <param name="id" example="1">The coffee id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            await _coffeeService.RemoveAsync(id);

            return NoContent();
        }
    }
}
