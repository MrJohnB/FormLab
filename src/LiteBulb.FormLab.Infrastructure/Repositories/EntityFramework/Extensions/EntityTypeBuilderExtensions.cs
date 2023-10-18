using LiteBulb.FormLab.Infrastructure.Entities.Definitions;
using LiteBulb.FormLab.Infrastructure.Entities.Submissions;
using Microsoft.EntityFrameworkCore;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Extensions;
public static class EntityTypeBuilderExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormDefinition>().ToTable("FormDefinition");
        modelBuilder.Entity<FieldDefinition>().ToTable("FieldDefinition");
        modelBuilder.Entity<FormSubmission>().ToTable("FormSubmission");
        modelBuilder.Entity<FieldSubmission>().ToTable("FieldSubmission");
    }
}
