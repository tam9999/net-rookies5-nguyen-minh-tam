using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IImageService _image;
        public static IWebHostEnvironment _webHostEnvironemnet;

        public ImageController(IImageService image, IMapper mapper, IWebHostEnvironment webHostEnvironemnet)
        {
            _mapper = mapper;
            _image = image;
            _webHostEnvironemnet = webHostEnvironemnet;
        }

        //Get all Image
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getImages = await _image.GetAsync();
                var imageVM = _mapper.Map<List<ImageViewModel>>(getImages);

                if (!imageVM.Any()) return NotFound("Image Empty");
                return Ok(imageVM);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        //Get one Image
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var getImage = await _image.GetByIdAsync(id);
                if (getImage == null || getImage.IsDeleted == true) return NotFound("Image not found :(");
                var imageVM = _mapper.Map<ImageViewModel>(getImage);
                var imgLink = _webHostEnvironemnet.WebRootPath + "\\uploads\\" + imageVM.ImageName;
                if (System.IO.File.Exists(imgLink))
                {
                    byte[] b = System.IO.File.ReadAllBytes(imgLink);
                    return File(b, "image/png");
                }
                return Ok(imageVM);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Create Image
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ImageViewModel info)
        {
            var baseURL = "https://localhost:5445/api/Image";
            try
            {
                if (info.File.Length > 0)
                {
                    string path = _webHostEnvironemnet.WebRootPath + "\\uploads\\";
                    string fileURL = _webHostEnvironemnet.WebRootPath + "\\uploads\\" + info.File.FileName;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + info.File.FileName))
                    {
                        info.File.CopyTo(fileStream);
                        fileStream.Flush();
                        info.ImageName = info.File.FileName;
                        info.ImageURL = baseURL;
                        var createImage = _mapper.Map<Image>(info);
                        var image = await _image.PostAsync(createImage);
                        var returnImage = _mapper.Map<ImageViewModel>(image);
                        return Ok("Upload Done");
                    }
                }
                else
                {
                    return BadRequest("Fail");
                }

            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong"+ex.Message);
            }
        }

        // Update Image
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ImageViewModel info)
        {
            var baseURL = "https://localhost:5445/api/Image";
            try
            {
                //var image = _mapper.Map<Image>(info);
                string path = _webHostEnvironemnet.WebRootPath + "\\uploads\\";
                string fileURL = _webHostEnvironemnet.WebRootPath + "\\uploads\\" + info.File.FileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + info.File.FileName))
                {
                    info.File.CopyTo(fileStream);
                    fileStream.Flush();
                    info.ImageName = info.File.FileName;
                    info.ImageURL = baseURL;
                    var putImage = _mapper.Map<Image>(info);
                    var image = await _image.PutAsync(id, putImage);
                    var returnImage = _mapper.Map<ImageViewModel>(image);
                    return Ok("Upload Done");
                }
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        // Delete Image
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var checkImage = await _image.GetByIdAsync(id);
                if (checkImage == null || checkImage.IsDeleted == true) return NotFound("Image not found");
                await _image.DeleteAsync(id);
                return Ok("Image Deleted");
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //public class ImageModel
        //{
        //    public int Id { get; set; }
        //    public int VegetableId { get; set; }
        //    public string ImageURL { get; set; }
        //    public bool IsDeleted { get; set; }
        //}

    }
}
