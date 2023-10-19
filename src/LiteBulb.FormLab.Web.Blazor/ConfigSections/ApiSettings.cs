namespace LiteBulb.FormLab.Web.Blazor.ConfigSections;

/// <summary>
/// URL values for the REST API.
/// </summary>
public class ApiSettings : IApiSettings 
{
    /// <summary>
    /// URI of Activities controller.
    /// </summary>
    public string ActivitiesRequestUri { get; set; } = string.Empty;

    /// <summary>
    /// URI of Positions controller.
    /// </summary>
    public string PositionsRequestUri { get; set; } = string.Empty;
}
