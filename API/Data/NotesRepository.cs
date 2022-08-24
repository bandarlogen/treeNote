using API.DTOs;
using API.Helpers;
using API.Interfaces;
using AutoMapper;

namespace API.Data;

public class NotesRepository : INotesRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public NotesRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedList<NoteDto>> GetNotesAsync(PaginationParams paginationParams)
    {
        var query = 
            from note in _context.Notes
            orderby note.Sent descending
            select new NoteDto
            {
                ID = note.ID,
                Send = note.Sent,
                Title = note.Title,
                Text = note.Text,
                Tags = note.Tags.Select(t => new NoteTagsDto
                {
                    TagID = t.TagID,
                    Caption = t.Tag.Caption
                }).ToList()
            };

        return await PagedList<NoteDto>.CreateAsync(query, paginationParams.PageNumber, paginationParams.PageSize);
    }

    public async Task<PagedList<NoteDto>> GetNotesByTagAsync(string tagID, PaginationParams paginationParams)
    {
        var query = 
            from noteByTag in _context.NotesTags
            where noteByTag.TagID == tagID
            orderby noteByTag.Sent descending
            select new NoteDto
            {
                ID = noteByTag.NoteID,
                Send = noteByTag.Note.Sent,
                Title = noteByTag.Note.Title,
                Text = noteByTag.Note.Text,
                Tags = noteByTag.Note.Tags.Select(t => new NoteTagsDto
                {
                    TagID = t.TagID,
                    Caption = t.Tag.Caption
                }).ToList()
            };

        return await PagedList<NoteDto>.CreateAsync(query, paginationParams.PageNumber, paginationParams.PageSize);
    }
}