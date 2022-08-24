using API.DTOs;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Data;

public class TagsRepository : ITagsRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TagsRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedList<TagDto>> GetTagsAsync(PaginationParams paginationParams)
    {
        var query = _context.Tags
            .ProjectTo<TagDto>(_mapper.ConfigurationProvider)      
            .AsQueryable();

        return await PagedList<TagDto>.CreateAsync(query, paginationParams.PageNumber, paginationParams.PageSize);
    }
}