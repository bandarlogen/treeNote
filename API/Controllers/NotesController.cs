using API.Extentions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class NotesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public NotesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetNotes([FromQuery] PaginationParams paginationParams)
    {
        var tags = await _unitOfWork.NotesRepository.GetNotesAsync(paginationParams);

        Response.AddPaginationHeader(tags.CurrentPage, tags.PageSize, tags.TotalCount, tags.TotalPages);

        return Ok(tags);
    }

    [HttpGet("{tagID}")]
    public async Task<ActionResult<string>> GetNotesByTag(string tagID, [FromQuery] PaginationParams paginationParams)
    {
        var tags = await _unitOfWork.NotesRepository.GetNotesByTagAsync(tagID.ToLower(), paginationParams);

        Response.AddPaginationHeader(tags.CurrentPage, tags.PageSize, tags.TotalCount, tags.TotalPages);

        return Ok(tags);
    }
}