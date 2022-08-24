using API.Extentions;

namespace API.Entities;

public class Note
{
    public int ID { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    // for notes ordering
    public DateTime Sent { get; set; } = DateTime.UtcNow.SetKindUtc();
    public virtual ICollection<NoteTag> Tags { get; set; } = null!;
}