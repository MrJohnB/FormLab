﻿namespace LiteBulb.FormLab.Infrastructure.Entities.Metadata;
public class FieldMetadata : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
