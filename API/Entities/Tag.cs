namespace API.Entities;

public class Tag
{
    public string ID { get; set; } = null!;
    public string Caption { get; set; } = null!;
    public virtual ICollection<NoteTag> Notes { get; set; } = null!;
}