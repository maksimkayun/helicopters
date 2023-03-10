using Common;
using HelicoptersService.Contracts;
using HelicoptersService.Services;
using HelicoptersService.Store;
using Microsoft.AspNetCore.Mvc;

namespace HelicoptersService.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
[ProducesResponseType(500, Type = typeof(String))]
[ProducesResponseType(404, Type = typeof(String))]
public class HelicoptersController : Controller
{
    private readonly IHelicopterService _service;

    public HelicoptersController(IHelicopterService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(String))]
    [ProducesResponseType(404)]
    public IActionResult Create(CreateHelicopterRequest request)
    {
        Helicopter helicopter = null;
        try
        {
            helicopter = MapUtil<CreateHelicopterRequest, Helicopter>.Map(request);
            _service.CreateAsync(helicopter);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok($"Success! Id: {helicopter.Id}");
    }

    [HttpPost("{id}")]
    [ProducesResponseType(200, Type = typeof(Helicopter))]
    public async Task<IActionResult> Read(string id)
    {
        Helicopter? result;
        try
        {
            result = _service.GetAsync(id).Result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return result == null ? NotFound($"Id {id} not found in storage") : Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(List<Helicopter>))]
    public async Task<IActionResult> ReadList(ReadHelicoptersListRequest request)
    {
        List<Helicopter> result;
        try
        {
            result = _service.GetListAsync(request.Skip, request.Take).Result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(result);
    }

    [HttpPost("{id}")]
    [ProducesResponseType(200, Type = typeof(Helicopter))]
    public IActionResult Update(string id, UpdateHelicopterRequest updateHelicopter)
    {
        Helicopter? result = null;
        try
        {
            updateHelicopter.Id = id;
            result = _service.UpdateAsync(id, MapUtil<UpdateHelicopterRequest, Helicopter>.Map(updateHelicopter))
                .Result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return result == null ? NotFound($"Id {id} not found in storage") : Ok(result);
    }

    [HttpPost("{id}")]
    [ProducesResponseType(200, Type = typeof(Helicopter))]
    public IActionResult Delete(string id)
    {
        Helicopter? result = null;
        try
        {
            result = _service.RemoveAsync(id).Result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return result == null ? NotFound($"Id {id} not found in storage") : Ok(result);
    }

    [HttpPost("{id}")]
    [ProducesResponseType(200, Type = typeof(Helicopter))]
    public IActionResult Recover(string id)
    {
        Helicopter? result = null;
        try
        {
            result = _service.RecoverAsync(id).Result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return result == null ? NotFound($"Id {id} not found in storage") : Ok(result);
    }

    [HttpPost("{id}")]
    [ProducesResponseType(200, Type = typeof(HelicopterManufacturer))]
    public IActionResult Aggregation(string id)
    {
        HelicopterManufacturer? result = null;
        try
        {
            result = _service.AggregateAsync(id).Result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return result == null ? NotFound($"Id {id} not found in storage") : Ok(result);
    }
}