using API.DTOs;
using API.Helpers;

namespace API.Interfaces;

public interface INotesRepository
{
    Task<PagedList<NoteDto>> GetNotesAsync(PaginationParams paginationParams);
    Task<PagedList<NoteDto>> GetNotesByTagAsync(string tagID, PaginationParams paginationParams);
}