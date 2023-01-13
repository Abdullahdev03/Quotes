using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers;


  [ApiController]
  [Route("[controller]")]
  public class CategoryController : ControllerBase
  {
    private CategoryService _categoryService;
    public CategoryController()
    {
      _categoryService = new CategoryService();
    }
    [HttpGet("Category")]
    public List<CategoryDto> Categories()
    {
      return _categoryService.GetCategories();
    }
    [HttpPost("Add")]
    public bool Add(CategoryDto category)
    {
      return _categoryService.AddCategory(category);
    }

    [HttpPut("Update")]
    public bool Update(CategoryDto category)
    {
      return _categoryService.UpdateCategory(category);
    }
    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
      return _categoryService.DeleteCategory(id);
    }
  }
