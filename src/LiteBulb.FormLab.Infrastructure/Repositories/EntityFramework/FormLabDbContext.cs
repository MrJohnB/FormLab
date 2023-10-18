using LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework;
public class FormLabDbContext : DbContext
{
    //public DbSet<FormMetadata> FormMetadata => Set<FormMetadata>();
    //public DbSet<FieldMetadata> FieldMetadata => Set<FieldMetadata>();
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
