﻿namespace LiteBulb.FormLab.Shared.Entities;
public abstract class Auditable : IAuditable
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset LastModified { get; set; }
}
