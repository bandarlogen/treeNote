using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    public DbSet<NoteTag> NotesTags { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Note>()
            .HasIndex(n => n.Sent);

        builder.Entity<NoteTag>()
            .HasKey(nt => new {nt.NoteID, nt.TagID});

        builder.Entity<NoteTag>()
            .HasIndex(nt => new {nt.TagID, nt.Sent});
    }
}