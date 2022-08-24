using API.Entities;

namespace API.Data;

public static class NotesInitializer
{
    public static void Initialize(DataContext context)
    {
        context.Database.EnsureCreated();

        if (context.Tags.Any())
            return;

        if (context.Notes.Any())
            return;

        var tags = new Tag[]
        {
            new Tag{ID="link", Caption="Link"},
            new Tag{ID="quote", Caption="Quote"},
            new Tag{ID="other", Caption="Other"}
        };

        foreach (Tag tag in tags)
            context.Tags.Add(tag);
        
        context.SaveChanges();

        var notes = new Note[]
        {
            new Note{ID=1, Title="Link 1", Text="link 1 text"},
            new Note{ID=2, Title="Link 2", Text="link 2 text"},
            new Note{ID=3, Title="Quote 1", Text="quote 1 text"},
            new Note{ID=4, Title="Quote 2", Text="quote 2 text"}
        };

        foreach (Note note in notes)
            context.Notes.Add(note);
        
        context.SaveChanges();

        var notestags = new NoteTag[]
        {
            new NoteTag{TagID="link", NoteID=1},
            new NoteTag{TagID="link", NoteID=2},
            new NoteTag{TagID="other", NoteID=2},
            new NoteTag{TagID="quote", NoteID=3},
            new NoteTag{TagID="quote", NoteID=4},
            new NoteTag{TagID="other", NoteID=4}
        };

        foreach (NoteTag notetag in notestags)
            context.NotesTags.Add(notetag);
        
        context.SaveChanges();
    }
}
