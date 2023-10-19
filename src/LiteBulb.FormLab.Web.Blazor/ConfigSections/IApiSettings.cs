namespace LiteBulb.FormLab.Web.Blazor.ConfigSections;

public interface IApiSettings
{
    /// <summary>
    /// URI of Activities controller.
    /// </summary>
    string ActivitiesRequestUri { get; set; }

    /// <summary>
    /// URI of Positions controller.
    /// </summary>
    string PositionsRequestUri { get; set; }
}
