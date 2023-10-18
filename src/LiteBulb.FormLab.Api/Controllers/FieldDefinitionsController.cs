using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Shared.Exceptions;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace LiteBulb.FormLab.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class FieldDefinitionsController : ControllerBase // Controller
{
    // TODO: do mapping from Model to DTO in controller?

    private readonly ILogger<FieldDefinitionsController> _logger;
    private readonly IService<FieldDefinition, int> _fieldDefinitionService;

    public FieldDefinitionsController(ILogger<FieldDefinitionsController> logger, IService<FieldDefinition, int> fieldDefinitionService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fieldDefinitionService = fieldDefinitionService ?? throw new ArgumentNullException(nameof(fieldDefinitionService));
    }

    /// <summary>
    /// Get list of all FieldDefinition objects from the database.
    /// </summary>
    /// <remarks>Returns 404 Not Found if list is empty</remarks>
    /// <example>GET api/v1/FieldDefinitions</example>
    /// <returns>FieldDefinition object collection</returns>
    /// <response code="200" cref="FieldDefinition">Retrieved list of objects</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FieldDefinition))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        _logger.LogDebug($"Entering controller method: {nameof(GetAllAsync)}");

        var response = await _fieldDefinitionService.GetAsync();

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
    /// Get a FieldDefinition object by id field from database.
    /// </summary>
    /// <example>GET api/v1/FieldDefinitions/5</example>
    /// <param name="id">Id of the FieldDefinition to retreive</param>
    /// <returns>FieldDefinition object</returns>
    /// <response code="200" cref="FieldDefinition">Retrieved object</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FieldDefinition))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _logger.LogDebug($"Entering controller method: {nameof(GetByIdAsync)}");

        var response = await _fieldDefinitionService.GetAsync(id);

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
    /// Add a new CustFieldDefinitionomer object to database.
    /// </summary>
    /// <remarks>Do not set Id field to a non-default value.</remarks>
    /// <example>POST api/FieldDefinitions</example>
    /// <param name="fieldDefinition">FieldDefinition object to add (JSON)</param>
    /// <returns>Resource URI location of newly created object</returns>
    /// <response code="201" cref="FieldDefinition">Created object</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FieldDefinition))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] FieldDefinition fieldDefinition)
    {
        _logger.LogDebug($"Entering controller method: {nameof(CreateAsync)}");

        if (fieldDefinition.Id is not null and not 0)
        {
            return BadRequest($"FieldDefinition.Id property must be null (or absent) or {default(int)} for Create.");
        }

        var response = await _fieldDefinitionService.AddAsync(fieldDefinition);

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
    /// Update a FieldDefinition object in the database.
    /// </summary>
    /// <remarks>Do not set FieldDefinition.Id field to a non-default value.</remarks>
    /// <example>PUT api/FieldDefinitions/5</example>
    /// <param name="id">Id of the object to update</param>
    /// <param name="fieldDefinition">FieldDefinition object to update (JSON)</param>
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
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] FieldDefinition fieldDefinition)
    {
        _logger.LogDebug($"Entering controller method: {nameof(UpdateAsync)}");

        if (fieldDefinition.Id is not null and not 0)
        {
            return BadRequest($"FieldDefinition.Id property must be null (or absent) or {default(int)} for Update.");
        }

        var response = await _fieldDefinitionService.UpdateAsync(id, fieldDefinition);

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
    /// Delete a FieldDefinition object from the database.
    /// </summary>
    /// <example>DELETE api/FieldDefinitions/5</example>
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

        var response = await _fieldDefinitionService.DeleteAsync(id);

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
