namespace API.DTOs;

public class NoteDto
{
    public int ID { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime Send { get; set; }
    public ICollection<NoteTagsDto> Tags { get; set; } = null!;
}