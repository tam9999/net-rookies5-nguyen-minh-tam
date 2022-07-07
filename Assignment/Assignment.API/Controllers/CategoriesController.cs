using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        ICategoryService categoryService;
        public CategoriesController(ICategoryService _categoryService)
        {
            this.categoryService = _categoryService;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            try
            {
                var categories = await categoryService.GetAllCategoryAsync();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategoryAsync(int? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                var category = await categoryService.GetCategoryAsync(categoryId);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{categoryId}")]
        [AllowAnonymous]
        //[Route("GetCategoryDetail")]
        public async Task<IActionResult> GetCategoryDetailAsync(int? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                var catagoryDetail = await categoryService.GetCategoryDetailAsync(categoryId);

                if (catagoryDetail == null)
                {
                    return NotFound();
                }

                return Ok(catagoryDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryId = await categoryService.AddCategoryAsync(model);
                    if (categoryId > 0)
                    {
                        return Ok(categoryId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(int? CategoryId)
        {
            int result = 0;

            if (CategoryId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await categoryService.DeleteCategoryAsync(CategoryId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.UpdateCategoryAsync(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    } 
        
}
