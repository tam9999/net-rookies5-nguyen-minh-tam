﻿using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetCategoryById")]
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{categoryId}")]
        [AllowAnonymous]

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

        //[Authorize]
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var categoryId = await categoryService.AddCategoryAsync(request);
                if (categoryId == 0)
                {
                    return BadRequest();
                }
                var data = await categoryService.GetCategoryAsync(categoryId);
                if (data == null)
                {
                    return NotFound($"Cannot find a cake with Id: {categoryId}");
                }
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(int? categoryId)
        {
            int result = 0;

            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await categoryService.DeleteCategoryAsync(categoryId);
                if (result == 0)
                {
                    return NotFound($"Cannot find a cake with Id: {categoryId}");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await categoryService.UpdateCategoryAsync(request);

                if (result == 0)
                {
                    return BadRequest();
                }

                var data = await categoryService.GetCategoryAsync(request.Id);
                if (data == null)
                {
                    return NotFound($"Cannot find a cake with Id: {request.Id}");
                }
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    } 
        
}
