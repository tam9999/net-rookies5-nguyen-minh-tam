using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
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
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var categories = await categoryService.GetAllCategory();
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
        public async Task<IActionResult> GetCategories(int? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                var category = await categoryService.GetCategories(categoryId);

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

        [HttpGet]
        [Route("GetCategoryDetail")]
        public async Task<IActionResult> GetCategoryDetail(int? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                var catagoryDetail = await categoryService.GetCategoryDetail(categoryId);

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
        public async Task<IActionResult> AddCategory([FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryId = await categoryService.AddCategory(model);
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
        public async Task<IActionResult> DeleteCategory(int? CategoryId)
        {
            int result = 0;

            if (CategoryId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await categoryService.DeleteCategory(CategoryId);
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
        public async Task<IActionResult> UpdateCategory([FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.UpdateCategory(model);

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
