using Microsoft.AspNetCore.Mvc;
using RedisSample.Services;

namespace RedisSample.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("getall")]
    public  IActionResult GetAll()
    {
        return Ok(_categoryService.GetAllCategory());
    }
}

