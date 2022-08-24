using API.Extentions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TagsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public TagsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetTags([FromQuery] PaginationParams paginationParams)
    {        
        var tags = await _unitOfWork.TagsRepository.GetTagsAsync(paginationParams);

        Response.AddPaginationHeader(tags.CurrentPage, tags.PageSize, tags.TotalCount, tags.TotalPages);

        return Ok(tags);
    }
}