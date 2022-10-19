using AutoMapper;
using Category.API.Core.Manager;
using Category.API.Core.Models.Domain;
using Category.API.Core.Models.Request;
using Category.API.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Category.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponseModel>> GetCategories()
        {
            var categories = _categoryManager.GetAllCategories();

            return Ok(_mapper.Map<IEnumerable<CategoryResponseModel>>(categories));
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryResponseModel> GetCategoryById(int id)
        {
            var category = _categoryManager.GetCategoryById(id);

            if (category is null)
                return NotFound();

            return Ok(_mapper.Map<CategoryResponseModel>(category));
        }

        [HttpPost]
        public ActionResult<CategoryResponseModel> CreateCategory(CategoryRequestModel requestModel)
        {
            var category = _mapper.Map<CategoryModel>(requestModel);

            _categoryManager.CreateCategory(category);
            _categoryManager.SaveChanges();

            var response = _mapper.Map<CategoryResponseModel>(category);

            return CreatedAtRoute(nameof(GetCategoryById), new { Id = response.Id }, response);
        }
    }
}
