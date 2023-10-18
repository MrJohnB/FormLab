using LiteBulb.FormLab.Infrastructure.Entities.Metadata;
using LiteBulb.FormLab.Infrastructure.Entities.Submissions;
using Microsoft.EntityFrameworkCore;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Extensions;
public static class EntityTypeBuilderExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormMetadata>().ToTable("FormMetadata");
        modelBuilder.Entity<FieldMetadata>().ToTable("FieldMetadata");
        modelBuilder.Entity<FormSubmission>().ToTable("FormSubmission");
        modelBuilder.Entity<FieldSubmission>().ToTable("FieldSubmission");
    }
}
