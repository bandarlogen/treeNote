using API.Extentions;

namespace API.Entities;

public class NoteTag
{
    public int NoteID { get; set; }
    public string TagID { get; set; } = null!;
    public DateTime Sent { get; set; } = DateTime.UtcNow.SetKindUtc();
    public virtual Note Note { get; set; } = null!;
    public virtual Tag Tag { get; set; } = null!;
}