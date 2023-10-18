using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Shared.Exceptions;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace LiteBulb.FormLab.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class FormSubmissionsController : ControllerBase // Controller
{
    // TODO: do mapping from Model to DTO in controller?

    private readonly ILogger<FormSubmissionsController> _logger;
    private readonly IService<FormSubmission, int> _formSubmissionService;

    public FormSubmissionsController(ILogger<FormSubmissionsController> logger, IService<FormSubmission, int> formSubmissionService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _formSubmissionService = formSubmissionService ?? throw new ArgumentNullException(nameof(formSubmissionService));
    }

    /// <summary>
    /// Get list of all FormSubmission objects from the database.
    /// </summary>
    /// <remarks>Returns 404 Not Found if list is empty</remarks>
    /// <example>GET api/v1/FormSubmissions</example>
    /// <returns>FormSubmission object collection</returns>
    /// <response code="200" cref="FormSubmission">Retrieved list of objects</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FormSubmission))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        _logger.LogDebug($"Entering controller method: {nameof(GetAllAsync)}");

        var response = await _formSubmissionService.GetAsync();

        if (response is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (response.HasErrors)
        {
            return response.Exception switch
            {
                NotFoundException => NotFound(response.ErrorMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, response.ErrorMessage)
            };
        }

        return Ok(response.Result);
    }

    /// <summary>
    /// Get a FormSubmission object by id field from database.
    /// </summary>
    /// <example>GET api/v1/FormSubmission/5</example>
    /// <param name="id">Id of the FormSubmission to retreive</param>
    /// <returns>FormSubmission object</returns>
    /// <response code="200" cref="FormSubmission">Retrieved object</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FormSubmission))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _logger.LogDebug($"Entering controller method: {nameof(GetByIdAsync)}");

        var response = await _formSubmissionService.GetAsync(id);

        if (response is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (response.HasErrors)
        {
            return response.Exception switch
            {
                BadRequestException => BadRequest(response.ErrorMessage),
                NotFoundException => NotFound(response.ErrorMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        return Ok(response.Result);
    }

    /// <summary>
    /// Add a new FormSubmission object to database.
    /// </summary>
    /// <remarks>Do not set Id field to a non-default value.</remarks>
    /// <example>POST api/FormSubmissions</example>
    /// <param name="formSubmission">FormSubmission object to add (JSON)</param>
    /// <returns>Resource URI location of newly created object</returns>
    /// <response code="201" cref="FormSubmission">Created object</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FormSubmission))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] FormSubmission formSubmission)
    {
        _logger.LogDebug($"Entering controller method: {nameof(CreateAsync)}");

        if (formSubmission.Id is not null and not 0)
        {
            return BadRequest($"FormSubmission.Id property must be null (or absent) or {default(int)} for Create.");
        }

        var response = await _formSubmissionService.AddAsync(formSubmission);

        if (response is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (response.HasErrors)
        {
            return response.Exception switch
            {
                BadRequestException => BadRequest(response.ErrorMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError, response.ErrorMessage)
            };
        }

        return CreatedAtAction(
            actionName: nameof(GetByIdAsync),
            routeValues: new { response.Result?.Id },
            value: response.Result);
    }

    /// <summary>
    /// Update a FormSubmission object in the database.
    /// </summary>
    /// <remarks>Do not set FormSubmission.Id field to a non-default value.</remarks>
    /// <example>PUT api/FormSubmissions/5</example>
    /// <param name="id">Id of the object to update</param>
    /// <param name="formSubmission">FormSubmission object to update (JSON)</param>
    /// <returns>Number of updated objects</returns>
    /// <response code="200">Number of updated objects</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] FormSubmission formSubmission)
    {
        _logger.LogDebug($"Entering controller method: {nameof(UpdateAsync)}");

        if (formSubmission.Id is not null and not 0)
        {
            return BadRequest($"FormSubmission.Id property must be null (or absent) or {default(int)} for Update.");
        }

        var response = await _formSubmissionService.UpdateAsync(id, formSubmission);

        if (response is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (response.HasErrors)
        {
            return response.Exception switch
            {
                BadRequestException => BadRequest(response.ErrorMessage),
                NotFoundException => NotFound(response.ErrorMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        return Ok(response.Result);
    }

    /// <summary>
    /// Delete a FormSubmission object from the database.
    /// </summary>
    /// <example>DELETE api/FormSubmissions/5</example>
    /// <param name="id">Id of the object to delete</param>
    /// <returns>Number of deleted objects</returns>
    /// <response code="200">Number of deleted objects</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        _logger.LogDebug($"Entering controller method: {nameof(DeleteByIdAsync)}");

        var response = await _formSubmissionService.DeleteAsync(id);

        if (response is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (response.HasErrors)
        {
            return response.Exception switch
            {
                BadRequestException => BadRequest(response.ErrorMessage),
                NotFoundException => NotFound(response.ErrorMessage),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        return Ok(response.Result);
    }
}
