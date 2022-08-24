namespace API.Interfaces;

public interface IUnitOfWork
{
    ITagsRepository TagsRepository { get; }
    INotesRepository NotesRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}