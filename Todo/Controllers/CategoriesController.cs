using Application.DTOs.Categories;
using Application.Features.Categories.Commands.AddNewCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Queries.GetCategoryById;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private string ItemName = "Category";

        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCategories(string? searchText)
        {
            var results = await _mediator.Send(new GetAllCategoriesQuery
            {
                CategoryName = searchText,
            });

            return Ok(results);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery
            {
                CategoryId = id
            });

            if (result == null)
            {
                return NotFound(ControllerResponses.NotFound(ItemName,id));
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto dto)
        {
            var result = await _mediator.Send(new AddCategoryCommand
            {
                dto= dto
            });

            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");
            
            var result = await _mediator.Send(new UpdateCategoryCommand 
            {
                Id = id,
                dto= dto
            });

            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand
            {
                CategoryId = id
            });

            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName,id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }
    }
}
