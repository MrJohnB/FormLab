using LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework;
public class FormLabDbContext : DbContext
{
    //public DbSet<FormDefinition> FormDefinition => Set<FormDefinition>();
    //public DbSet<FieldDefinition> FieldDefinition => Set<FieldDefinition>();
    //public DbSet<FormSubmission> FormSubmissions => Set<FormSubmission>();
    //public DbSet<FieldSubmission> FieldSubmissions => Set<FieldSubmission>();

    public FormLabDbContext(DbContextOptions<FormLabDbContext> options)
        : base(options) { }

    protected FormLabDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEntities();
    }
}
