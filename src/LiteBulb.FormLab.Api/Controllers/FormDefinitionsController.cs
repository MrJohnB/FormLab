using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Shared.Exceptions;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace LiteBulb.FormLab.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class FormDefinitionsController : ControllerBase // Controller
{
    // TODO: do mapping from Model to DTO in controller?

    private readonly ILogger<FormDefinitionsController> _logger;
    private readonly IService<FormDefinition, int> _formDefinitionService;

    public FormDefinitionsController(ILogger<FormDefinitionsController> logger, IService<FormDefinition, int> formDefinitionService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _formDefinitionService = formDefinitionService ?? throw new ArgumentNullException(nameof(formDefinitionService));
    }

    /// <summary>
    /// Get list of all FormDefinition objects from the database.
    /// </summary>
    /// <remarks>Returns 404 Not Found if list is empty</remarks>
    /// <example>GET api/v1/FormDefinitions</example>
    /// <returns>FormDefinition object collection</returns>
    /// <response code="200" cref="FormDefinition">Retrieved list of objects</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FormDefinition))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        _logger.LogDebug($"Entering controller method: {nameof(GetAllAsync)}");

        var response = await _formDefinitionService.GetAsync();

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
    /// Get a FormDefinition object by id field from database.
    /// </summary>
    /// <example>GET api/v1/FormDefinitions/5</example>
    /// <param name="id">Id of the FormDefinition to retreive</param>
    /// <returns>FormDefinition object</returns>
    /// <response code="200" cref="FormDefinition">Retrieved object</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FormDefinition))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _logger.LogDebug($"Entering controller method: {nameof(GetByIdAsync)}");

        var response = await _formDefinitionService.GetAsync(id);

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
    /// Add a new FormDefinition object to database.
    /// </summary>
    /// <remarks>Do not set Id field to a non-default value.</remarks>
    /// <example>POST api/FormDefinitions</example>
    /// <param name="formDefinition">FormDefinition object to add (JSON)</param>
    /// <returns>Resource URI location of newly created object</returns>
    /// <response code="201" cref="FormDefinition">Created object</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FormDefinition))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] FormDefinition formDefinition)
    {
        _logger.LogDebug($"Entering controller method: {nameof(CreateAsync)}");

        if (formDefinition.Id is not null and not 0)
        {
            return BadRequest($"FormDefinition.Id property must be null (or absent) or {default(int)} for Create.");
        }

        var response = await _formDefinitionService.AddAsync(formDefinition);

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
    /// Update a FormDefinition object in the database.
    /// </summary>
    /// <remarks>Do not set FormDefinition.Id field to a non-default value.</remarks>
    /// <example>PUT api/FormDefinitions/5</example>
    /// <param name="id">Id of the object to update</param>
    /// <param name="formDefinition">FormDefinition object to update (JSON)</param>
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
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] FormDefinition formDefinition)
    {
        _logger.LogDebug($"Entering controller method: {nameof(UpdateAsync)}");

        if (formDefinition.Id is not null and not 0)
        {
            return BadRequest($"FormDefinition.Id property must be null (or absent) or {default(int)} for Update.");
        }

        var response = await _formDefinitionService.UpdateAsync(id, formDefinition);

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
    /// Delete a FormDefinition object from the database.
    /// </summary>
    /// <example>DELETE api/FormDefinitions/5</example>
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

        var response = await _formDefinitionService.DeleteAsync(id);

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
