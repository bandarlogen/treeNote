using API.DTOs;
using API.Helpers;

namespace API.Interfaces;

public interface ITagsRepository
{
    Task<PagedList<TagDto>> GetTagsAsync(PaginationParams paginationParams);
}